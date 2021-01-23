        public ContentViewModel(Content content = null, string pk = null, 
                                string rk = null, string user = null)
        {
            this.Content = content ?? new Content();
            if (pk != null) this.Content.PartitionKey = pk;
            if (rk != null) this.Content.RowKey = pk;
            if (user != null) this.Content.CreatedBy = user;
            this.Content.Created = DateTime.Now;
        }        
