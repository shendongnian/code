        static void TestMethod()
        {
            using (Model1 ctx = new Model1())
            {
                Console.WriteLine("Count = {0}", ctx.Test.Count());
                Console.WriteLine("Has Value 'Test1' = {0}", ctx.Test.Count(x => x.Value == "Test1"));
                Console.WriteLine("Has Value 'Test2' = {0}", ctx.Test.Count(x => x.Value == "Test2"));
            }
            using (Transactions.TransactionScope scope = new Transactions.TransactionScope())
            {
                using (Model1 ctx = new Model1())
                {
                    ctx.Test.Add(new Test { Value = "Test1" });
                    Console.WriteLine("Add 'Test1'");
                    Console.WriteLine("SaveChanges = {0}", ctx.SaveChanges());
                }
                using (Transactions.TransactionScope scope2 = new Transactions.TransactionScope(Transactions.TransactionScopeOption.Suppress))
                {
                    using (Model1 ctx = new Model1())
                    {
                        ctx.Test.Add(new Test { Value = "Test2" });
                        Console.WriteLine("Add 'Test2'");
                        Console.WriteLine("SaveChanges = {0}", ctx.SaveChanges());
                    }
                }
            }
            using (Model1 ctx = new Model1())
            {
                Console.WriteLine("Count = {0}", ctx.Test.Count());
                Console.WriteLine("Has Value 'Test1' = {0}", ctx.Test.Count(x => x.Value == "Test1"));
                Console.WriteLine("Has Value 'Test2' = {0}", ctx.Test.Count(x => x.Value == "Test2"));
            }
        }
