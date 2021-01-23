    public Form1()
    {
        InitializeComponent();
        for (int x = 0; x < 100; x++)
        {
            listView1.Items.Add("Item #" + x);
        }
    }
    private int y = 10;
    private void timer1_Tick(object sender, EventArgs e)
    {
        listView1.Items.Add("Item #" + y + "b");
        y += 10;
    }
