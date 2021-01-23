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
                Name          = "Washer",
                Make          = "Samsung",
                Model         = "Model No",
                SerialNumber  = serialNumber,
                PurchasePrice = 2500m
            };
            using( var logic = new ItemLogic() )
            {
                logic.Save( item );
                logic.Delete( item );                
                item = logic.Retrieve( serialNumber );
            }
            Assert.IsNull( item );
        }
