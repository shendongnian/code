        public Item Save( Item item )
        {
            Db4oDatabase.Database.Store( item );
            try
            {
                Db4oDatabase.Database.Commit();
            }
            catch( UniqueFieldValueConstraintViolationException )
            {
                Db4oDatabase.Database.Rollback();
                throw;
            }
            return this.Retrieve( item.SerialNumber );
        }
        [TestMethod]
        public void DeleteItem_Test()
        {
            string serialNumber = "DeleteItem_Test";
            
            Item item = new Item
            {
                Name          = "DeleteItem_Test",
                Make          = "Samsung",
                Model         = "Model No",
                SerialNumber  = serialNumber,
                PurchasePrice = 2500m
            };
            using( var logic = new ItemLogic() )
            {
                item = logic.Save( item );
                Assert.IsNotNull( item, "The Save operation in DeleteItem_Test failed. Therefore, the test could not continue." );
                
                item = null;
                item = logic.Retrieve( serialNumber );
                Assert.IsNotNull( item, "The Retrieve operation in DeleteItem_Test failed. Therefore, the test could not continue." );
                logic.Delete( item );
                item = logic.Retrieve( serialNumber );
            }
            Assert.IsNull( item );
        }
