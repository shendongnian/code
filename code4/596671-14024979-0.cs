    public Form1()
    {
        InitializeComponent();
         listPersons = new List<Person>();
     
        FillGrid();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (textBox1.Text.Length > 0)
        {
            Person p = new Person();
            p.Name = textBox1.Text;
            listPersons.Add(p);
            FillGrid();
        }
    }
    private void FillGrid()
    {
       dataGridView1.DataSource = listPersons;
    }
