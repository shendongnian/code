    public Form1()
    {
        InitializeComponent();
        this.dataGridView1.Rows.CollectionChanged += new CollectionChangeEventHandler(Rows_CollectionChanged);
    }
    void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
    {
        Debug.Print(e.Action.ToString()); // to use Debug.Print function add a using System.Diagnostics to your program
        Debug.Print(e.Element.ToString());
        DataGridViewRow row = (DataGridViewRow)e.Element;
    }
