        public ContentViewModel(string pk, string rk, string user)
        {
            this.Content = new Content();
            this.Content.PartitionKey = pk;
            this.Content.RowKey = rk;
            this.Content.Created = DateTime.Now;
            this.Content.CreatedBy = user;
        }
