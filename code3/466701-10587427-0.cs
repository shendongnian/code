    public Form1()
    {
        InitializeComponent();
    
        dataGridView1.AutoSize = true;
        dataGridView1.SizeChanged += new EventHandler(dataGridView1_SizeChanged);
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }
    
    void dataGridView1_SizeChanged(object sender, EventArgs e)
    {
        Width = dataGridView1.Width + 10;
    }
