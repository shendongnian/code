    public class StoredUserEntity : TableServiceEntity
    {
        public StoredUserEntity (string username)
        {
            this.PartitionKey = username;
            this.RowKey = Guid.NewGuid().ToString();
            this.Timestamp = DateTime.Now;
        }
        public string Email { get; set; }
        public string Name { get; set; }
    }
