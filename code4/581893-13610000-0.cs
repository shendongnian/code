    public class container
    {
        public menu menu { get; set; }
    }
    public class menu
    {
        public menuitem[] menuitems { get; set; }
    }
    public class menuitem
    {
        public string Label { get; set; }
        public string Listview { get; set; }
    }
