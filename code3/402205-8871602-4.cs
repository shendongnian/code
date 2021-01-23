    public class Model
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public bool Hidden { get; set; }
        public int Id { get; set; }
        public bool Sortable { get; set; }
        public SearchOption Searchoptions { get; set; }
        public int Width { get; set; }
        public bool Title { get; set; }
        public int WidthOrg { get; set; }
        public bool Resizable { get; set; }
        public string Label { get; set; }
        public bool Search { get; set; }
        public string Stype { get; set; }
    }
    public class SearchOption
    {
        public string[] Sopt { get; set; }
    }
