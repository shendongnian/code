    [Test]
    public void Can_Insert_Multiple()
    {
        using (MORMEngine engine = new MORMEngine(connectionString))
        {
            engine.OpenConnection();
            List<TestInventory> inventories = new List<TestInventory>();
            for (int i = 0; i < 10000; i++)
            {
                inventories.Add(new TestInventory
                {
                    Code = "test" + i
                });
            }
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int rows = engine.Add<TestInventory>(inventories);
            watch.Stop();
            Console.WriteLine("Completed in {0} ms.", watch.ElapsedMilliseconds);
            Assert.That(rows == 10000);
        }
    }
