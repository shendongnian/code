        [TestMethod]
        public void PopulateSomeMore()
        {
            const string conStr = "Data Source=(local);Initial Catalog=EfExperiment1; Integrated Security=True";
            var context = new MyDbContext(conStr);
            var container = context.Buckets.FirstOrDefault(c => c.ContainerId == "12345") ??
                            new Container { ContainerId = "12345" };
            var item3 = new Item { keyPart1 = "i3k1", keyPart2 = "i3k2", Container = container };
            var item4 = new Item { keyPart1 = "i4k1", keyPart2 = "i4k2", Container = container };
            context.Items.Add(item3);
            context.Items.Add(item4);
            context.SaveChanges();
        }
