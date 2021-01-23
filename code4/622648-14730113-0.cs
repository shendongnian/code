    class Program
    {
        static void Main(string[] args)
        {
            List<ItemObject> items = new List<ItemObject>()
            {
                new ItemObject() { Text = "Text 1", IsSelected = true },
                new ItemObject() { Text = "Text 2", IsSelected = true },
                new ItemObject() { Text = "ALL", IsSelected = true }
            };
            items.ForEach(x => { if (x.Text == "ALL") x.IsSelected = false; });
        }
    }
    class ItemObject
    {
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
