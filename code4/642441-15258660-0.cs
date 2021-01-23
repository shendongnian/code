        [TestMethod]
        public void Populate()
        {
            const string conStr = "Data Source=(local);Initial Catalog=EfExperiment1; Integrated Security=True";
            var context = new MyDbContext(conStr);
            var container = new Container { ContainerId = "12345" };
            var item1 = new Item { keyPart1 = "i1k1", keyPart2 = "i1k2", Container = container };
            var item2 = new Item { keyPart1 = "i2k1", keyPart2 = "i2k2", Container = container };
            context.Items.Add(item1);
            context.Items.Add(item2);
            context.SaveChanges();
        }
