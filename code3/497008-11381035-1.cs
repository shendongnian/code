        public ContentViewModel() { }
        public ContentViewModel(Content content)
        {
            this.Content = content;
        }
        public ContentViewModel(string pk): this(new Content)
        {
            this.Content.PartitionKey = pk;
            this.Content.Created = DateTime.Now;
        }
        public ContentViewModel(string pk, string rk): this(pk)
        {
            this.Content.RowKey = rk;
        }
        public ContentViewModel(string pk, string rk, string user): this(pk, rk)
        {
            this.Content.CreatedBy = user;
        }
