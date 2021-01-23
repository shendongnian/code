      [TestMethod()]
        public void CreateTestCheckContextCorrectly()
        {
            MailJobController target = new MailJobController();
            target.AddDessert("dessert for Omer");
            //With suppress, even if you rollback ambient trans, suppress will ignore ambient trans. You need to reference new context, previous context from controller may be disposed.
            using (var suppressscope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var newdbcontextref = new DbEntities();
                int recordcount = newdbcontextref.StatusDefinitions.Where(x => x.Name == "dessert for Omer").Count();
                Assert.AreEqual(0, recordcount);
            }
        }
