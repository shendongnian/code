        [TestMethod]
        public void PopulateSomeMoreAgain()
        {
            const string conStr = "Data Source=(local);Initial Catalog=EfExperiment1; Integrated Security=True";
            var context = new MyDbContext(conStr);
            var container = new Container { ContainerId = "12345" };
            var item5 = new Item { keyPart1 = "i5k1", keyPart2 = "i5k2", Container = container };
            var item6 = new Item { keyPart1 = "i6k1", keyPart2 = "i6k2", Container = container };
            context.Items.Add(item5);
            context.Items.Add(item6);
            context.SaveChanges();
        }
