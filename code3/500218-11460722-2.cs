    public class MenuItem{
        public string Caption {get; set;}
        public int Level {get; set; }
        public List<MenuItem> MenuItems {get; set;}
        public MenuItem(string caption){
            Caption = caption;
            MenuItems = new List<MenuItem>();
        }
    }
