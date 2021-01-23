    public partial class Form1 : Form
    {
        // embedded class
        class Node
        {
            public string Name { get; private set; }
            public string Column1 { get; private set; }
            public string Column2 { get; private set; }
            public string Column3 { get; private set; }
            public List<Node> Children { get; private set; }
            public Node(string name, string col1, string col2, string col3)
            {
                this.Name = name;
                this.Column1 = col1;
                this.Column2 = col2;
                this.Column3 = col3;
                this.Children = new List<Node>();
            }
        }
    
        // private fields
        private List<Node> data;
        private BrightIdeasSoftware.TreeListView treeListView;
    
        // constructor
        public Form1()
        {
            InitializeComponent();
            AddTree();
            InitializeData();
            FillTree();
        }
    
        // private methods
        private void FillTree()
        {
            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView.ChildrenGetter = x => (x as Node).Children;
    
            // create the tree columns and set the delegates to print the desired object proerty
            var nameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            nameCol.AspectGetter = x => (x as Node).Name;
    
            var col1 = new BrightIdeasSoftware.OLVColumn("Column1", "Column1");
            col1.AspectGetter = x => (x as Node).Column1;
                
            var col2 = new BrightIdeasSoftware.OLVColumn("Column2", "Column2");
            col2.AspectGetter = x => (x as Node).Column2;
    
            var col3 = new BrightIdeasSoftware.OLVColumn("Column3", "Column3");
            col3.AspectGetter = x => (x as Node).Column3;
    
            // add the columns to the tree
            this.treeListView.Columns.Add(nameCol);
            this.treeListView.Columns.Add(col1);
            this.treeListView.Columns.Add(col2);
            this.treeListView.Columns.Add(col3);
    
            // set the tree roots
            this.treeListView.Roots = data;
        }
    
        private void InitializeData()
        {
            // create fake nodes
            var parent1 = new Node("PARENT1", "-", "-", "-");
            parent1.Children.Add(new Node("CHILD_1_1", "A", "X", "1"));
            parent1.Children.Add(new Node("CHILD_1_2", "A", "Y", "2"));
            parent1.Children.Add(new Node("CHILD_1_3", "A", "Z", "3"));
    
            var parent2 = new Node("PARENT2", "-", "-", "-");
            parent2.Children.Add(new Node("CHILD_2_1", "B", "W", "7"));
            parent2.Children.Add(new Node("CHILD_2_2", "B", "Z", "8"));
            parent2.Children.Add(new Node("CHILD_2_3", "B", "J", "9"));
    
            var parent3 = new Node("PARENT3", "-", "-", "-");
            parent3.Children.Add(new Node("CHILD_3_1", "C", "R", "10"));
            parent3.Children.Add(new Node("CHILD_3_2", "C", "T", "12"));
            parent3.Children.Add(new Node("CHILD_3_3", "C", "H", "14"));
    
            data = new List<Node> { parent1, parent2, parent3 };
        }
    
        private void AddTree()
        {
            treeListView = new BrightIdeasSoftware.TreeListView();
            treeListView.Dock = DockStyle.Fill;
            this.Controls.Add(treeListView);
        }
    }
