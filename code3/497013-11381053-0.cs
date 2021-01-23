    public ContentViewModel(string pk, string rk = null, string user = null)
    {
        this.Content = new Content();
        this.Content.PartitionKey = pk;
        this.Content.RowKey = rk;
        this.Content.Created = DateTime.Now;
        this.Content.CreatedBy = user;
    }
