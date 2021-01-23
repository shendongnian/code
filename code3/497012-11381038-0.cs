    public ContentViewModel(string pk)
    {
     this.Content = new Content();
     this.Content.PartitionKey = pk;
     this.Content.Created = DateTime.Now;
    }
