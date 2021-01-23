    private void Form1_Load(object sender, EventArgs e)
    {
        button1.Click += MyMethod;
        dataGridView1.DoubleClick += MyMethod;
    }
    
    void MyMethod(object sender, EventArgs e)
    {
        //Do Stuff
    }
