    public class Page3ViewModel
    {
        public Page3ViewModel()
        {
            Items = new List<DataItem>
                {
                    new DataItem{Name = "One", Description = "First"},
                    new DataItem{Name = "Two", Description = "Second"},
                    new DataItem{Name = "Three", Description = "Third"},
                    new DataItem{Name = "Four", Description = "Fourth"},
                };
        }
        public IEnumerable<DataItem> Items { get; private set; }
    }
