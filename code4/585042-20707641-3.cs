     /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            Console.Title = "Divyang Demo ";
            var w = new Worker();
            w.Run();
            Console.ReadLine();
        }
    }
    
    internal class Worker
    {
        
        private object SyncObject = new object();
        public Worker()
        {
            var r = new Random();
            this.ObjectOfMyTestClass = new MyTestClass { MyInitval = r.Next(500) };
        }
        
        public MyTestClass ObjectOfMyTestClass { get; set; }
        
        public void Run()
        {
            Task readWork;
            readWork = Task.Factory.StartNew(
                action: () =>
                    {
                        for (;;)
                        {
                            Task.Delay(1000);
                            try
                            {
                                this.DoReadWork();
                            }
                            catch (Exception exception)
                            {
                                // Console.SetCursorPosition(80,80);
                                // Console.SetBufferSize(100,100);
                                Console.WriteLine("Read Exception : {0}", exception.Message);
                            }
                        }
                        // ReSharper disable FunctionNeverReturns
                    });
            Task writeWork;
            writeWork = Task.Factory.StartNew(
                action: () =>
                    {
                        for (int i = 0; i < int.MaxValue; i++)
                        {
                            Task.Delay(1000);
                            try
                            {
                                this.DoWriteWork();
                            }
                            catch (Exception exception)
                            {
                                Console.SetCursorPosition(80, 80);
                                Console.SetBufferSize(100, 100);
                                Console.WriteLine("write Exception : {0}", exception.Message);
                            }
                        
                            if (i == 5000)
                            {
                                ((IPseudoImmutable)this.ObjectOfMyTestClass).Freeze();
                            }
                        }
                    });
            Task.WaitAll();
        }
        /// <summary>
        /// The do read work.
        /// </summary>
        public void DoReadWork()
        {
            // ThreadId  where reading is done
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            // printing on screen
            lock (this.SyncObject)
            {
                Console.SetCursorPosition(0, 0);
                Console.SetBufferSize(290, 290);
                Console.WriteLine("\n");
                Console.WriteLine("Read Start");
                Console.WriteLine("Read => Thread Id: {0} ", threadId);
                Console.WriteLine("Read => this.objectOfMyTestClass.MyInitval: {0} ", this.ObjectOfMyTestClass.MyInitval);
                Console.WriteLine("Read => this.objectOfMyTestClass.MyString: {0} ", this.ObjectOfMyTestClass.MyString);
                
                Console.WriteLine("Read End");
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// The do write work.
        /// </summary>
        public void DoWriteWork()
        {
            // ThreadId  where reading is done
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            // random number generator
            var r = new Random();
            var count = r.Next(15);
            // new value for Int property
            var tempInt = r.Next(5000);
            this.ObjectOfMyTestClass.MyInitval = tempInt;
            // new value for string Property
            var tempString = "Randome" + r.Next(500).ToString(CultureInfo.InvariantCulture);
            this.ObjectOfMyTestClass.MyString = tempString;
            
            // printing on screen
            lock (this.SyncObject)
            {
                Console.SetBufferSize(290, 290);
                Console.SetCursorPosition(125, 25);
                
                Console.WriteLine("\n");
                Console.WriteLine("Write Start");
                Console.WriteLine("Write => Thread Id: {0} ", threadId);
                Console.WriteLine("Write => this.objectOfMyTestClass.MyInitval: {0} and New Value :{1} ", this.ObjectOfMyTestClass.MyInitval, tempInt);
                Console.WriteLine("Write => this.objectOfMyTestClass.MyString: {0} and New Value :{1} ", this.ObjectOfMyTestClass.MyString, tempString);
                              Console.WriteLine("Write End");
                Console.WriteLine("\n");
            }
        }
    }
    but still it will allow you to change property like array ,list . but if you apply more login in that then it may work for all type of property and field
