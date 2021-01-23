    [Gtk.TreeNode (ListOnly=true)]
    public class MyTreeNode : Gtk.TreeNode 
    {
        public MyTreeNode (string artist, string title, string color)
        {
            Artist = artist;
            Title = title; 
            Color = color;
        }
        [Gtk.TreeNodeValue (Column=0)]
        public string Artist;
        [Gtk.TreeNodeValue (Column=1)]
        public string Title;
        [Gtk.TreeNodeValue (Column=2)]
        public string Color;
    }
