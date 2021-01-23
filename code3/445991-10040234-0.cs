    private bool bindingHasBeenStarted = false;
    
    void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.DataSource = bindingList1;
        bindingHasBeenStarted = true;
    }
    
    void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
        if (bindingHasBeenStarted)
        {
           // do some stuff.. 
        }
    }
