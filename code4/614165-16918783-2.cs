    public Form1()
    {
        InitializeComponent();
        source = new SortableBindingList<MyClass>();
        source.Add(new MyClass() { Id = 1, Value = "one test" });
        source.Add(new MyClass() { Id = 2, Value = "second test" });
        source.Add(new MyClass() { Id = 3, Value = "another test" });
        source.PropertyChanged += source_PropertyChanged;
        dataGridView1.DataSource = source;
    }
    void source_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        MessageBox.Show(e.PropertyName);
        dataGridView1.DataSource = source;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        ((MyClass)source[0]).Id++;
    }
