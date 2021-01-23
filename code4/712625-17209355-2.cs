    public class MyViewModel
    {
        public MyViewModel()
        {
            Items = new List<CheckBoxItem>();
            Items.Add(new CheckBoxItem { Id = 23, Text = "Hello" });
        }
    
        public IList<CheckBoxItem> Items { get; set; }
    }
    
    public class CheckBoxItem
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string Text { get;set; }
    }
