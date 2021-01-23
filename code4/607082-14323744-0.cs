    public class CustomerEntity : TableServiceEntity
    {
        public CustomerEntity()
        {
            PartitionKey = "Customer";
            RowKey = Guid.NewGuid().ToString();
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public DateTime? LastOrderDate
        {
            get;
            set;
        }
    }
        static void InsertEntityBatchOperation()
        {
            var storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            var cloudTableClient = storageAccount.CreateCloudTableClient();
            var customer = new CustomerEntity()
            {
                FirstName = "John",
                LastName = "Smith",
                LastOrderDate = DateTime.UtcNow.Date.AddDays(-10)
            };
            var serviceContext = cloudTableClient.GetDataServiceContext();
            serviceContext.AddObject(tableName, customer);
            customer = new CustomerEntity()
            {
                FirstName = "Jane",
                LastName = "Smith",
                LastOrderDate = DateTime.UtcNow.Date.AddDays(-5)
            };
            serviceContext.AttachTo(tableName, customer, null);
            serviceContext.UpdateObject(customer);
            customer = new CustomerEntity()
            {
                FirstName = "John",
                LastName = "Doe",
                LastOrderDate = DateTime.UtcNow.Date.AddDays(-7)
            };
            serviceContext.AttachTo(tableName, customer, null);
            serviceContext.UpdateObject(customer);
            customer = new CustomerEntity()
            {
                FirstName = "Jane",
                LastName = "Doe",
                LastOrderDate = DateTime.UtcNow.Date.AddDays(-3)
            };
            serviceContext.AttachTo(tableName, customer, null);
            serviceContext.UpdateObject(customer);
            //Following will perform Insert Or Merge Entity Operation
            serviceContext.SaveChangesWithRetries(SaveChangesOptions.Batch);
            //Following will perform Insert Or Replace Entity Operation
            serviceContext.SaveChangesWithRetries(SaveChangesOptions.Batch | SaveChangesOptions.ReplaceOnUpdate);
        }
