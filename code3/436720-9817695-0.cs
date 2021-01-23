     public class TreeViewExample
    {
        public static void Main()
        {
            Gtk.Application.Init();
            new TreeViewExample();
            Gtk.Application.Run();
        }
        public TreeViewExample()
        {
            Gtk.Window window = new Gtk.Window("TreeView Example");
            window.SetSizeRequest(500, 200);
            Gtk.TreeView tree = new Gtk.TreeView();
            window.Add(tree);
            Gtk.TreeViewColumn Parent = new Gtk.TreeViewColumn();
            Parent.Title = "Parent";
            Gtk.CellRendererText Parent1 = new Gtk.CellRendererText();
            Parent.PackStart(Parent1, true);
            Gtk.TreeViewColumn ChildColoumn1 = new Gtk.TreeViewColumn();
            ChildColoumn1.Title = "Column 1";           
            Gtk.CellRendererText Child1 = new Gtk.CellRendererText();
            ChildColoumn1.PackStart(Child1, true);
            Gtk.TreeViewColumn ChildColumn2 = new Gtk.TreeViewColumn();
             ChildColumn2.Title = "Column 2";
            Gtk.CellRendererText Child2 = new Gtk.CellRendererText();
            ChildColumn2.PackStart(Child2, true);
            tree.AppendColumn(Parent);
            tree.AppendColumn(ChildColoumn1);
            tree.AppendColumn(ChildColumn2);
            Parent.AddAttribute(Parent1, "text", 0);
            ChildColoumn1.AddAttribute(Child1, "text", 1);
            ChildColumn2.AddAttribute(Child2, "text", 2);
            Gtk.TreeStore Tree = new Gtk.TreeStore(typeof(string), typeof(string), typeof(string));
            Gtk.TreeIter iter = Tree.AppendValues("Parent1");
            Tree.AppendValues(iter, "Child1", "Node 1");
            iter = Tree.AppendValues("Parent2");
            Tree.AppendValues(iter, "Child1", "Node 1","Node 2");          
            tree.Model = Tree;
            window.ShowAll();
        }
    }
