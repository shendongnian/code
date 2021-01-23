    public Form1()
    {
        InitializeComponent();
        this.dataGridView1.Rows.CollectionChanged += new CollectionChangeEventHandler(Rows_CollectionChanged);
    }
    void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
    {
        throw new NotImplementedException();
    }
