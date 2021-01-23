    ContextMenuStrip a = new ContextMenuStrip();
    public Form1()
    {
       InitializeComponent();
       this.Load += new EventHandler(Form1_Load);
    }
    void Form1_Load(object sender, EventArgs e)
    {
       Image img = null;
       a.Items.Add("Google", img, new System.EventHandler(ContextMenuClick));
       a.Items.Add("Yahoo", img, new System.EventHandler(ContextMenuClick));
       dataGridView1.ContextMenuStrip = a;
    }
