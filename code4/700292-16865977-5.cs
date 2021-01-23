    class Item 
    {
        private List<SubItem> SubItems { get; set; }
        private List<SubItem> SubItemsWithIdOne { get { return this.SubItems.Where(sub => sub.ID == 1); } }
    }
