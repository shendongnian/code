     public Form1()
     {
        InitializeComponent();
     }
     private void button1_Click(object sender, EventArgs e)
     {
        Form2 f = new Form2(this);
           
        f.ShowDialog();
        MyObject mo = f.GetMyObject();
     }
