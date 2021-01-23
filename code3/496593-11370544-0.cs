    public class IndexViewModel // or DetailsViewModel or whatever the Action Method is
    {
        public IEnumerable<Foo> Foos { get; set; }
        public SelectList DropDownBox { get; set; }
        public string Name { get; set; } // Textbox 1
        public string Description { get; set; } // Textbox 2
    }
