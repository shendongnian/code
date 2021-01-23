    class Window
    {
        public Window(int id) { this.ID = id; }
        public int ID { get; private set; }
        public int? ParentID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Options { get; set; }
        public string Actions { get; set; }
        public string Exit { get; set; }
    }
