        class Context
        {
            public ManualResetEvent sink;
            public DependentTransaction transaction;
        }
        static object syncRoot = new object();
        
        static void Main(string[] args)
        {
            using (var scope = new TransactionScope())
            {
                int cnt = 5;
                ManualResetEvent[] evt = new ManualResetEvent[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    var sink = new ManualResetEvent(false);
                    evt[i] = sink;
                    var context = new Context()
                    {
                        // clone transaction
                        transaction = Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete),
                        sink = sink
                    };
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Run), context);
                }
                // wait for all threads to finish
                ManualResetEvent.WaitAll(evt);
                using (var mc = new ModelContainer())
                {
                    // check database content
                    Console.WriteLine(mc.EntitySet.Count());
                }
                // after test is done, the transaction is rolled back and the database state is untouched
                Console.ReadKey();
            }
        }
                
        static void Run(object state)
        {
            var context = state as Context;
            // set ambient transaction
            Transaction oldTran = Transaction.Current;
            Transaction.Current = context.transaction;
           
            using (var mc = new ModelContainer())
            {
                mc.EntitySet.Add(new Entity()
                {
                    MyProp = "test"
                });
                // synchronize database access
                lock (syncRoot)
                {
                    mc.SaveChanges();
                }
            }
          
            // release dependent transaction
            context.transaction.Complete();            
            context.transaction.Dispose();
            Transaction.Current = oldTran;
            context.sink.Set();            
        }
    }
