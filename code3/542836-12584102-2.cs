    public Form1()
    {
        InitializeComponent();
    
        // Make TabControl
        TabControl tabControl1 = new TabControl();
        tabControl1.TabPages.Add(new TabPage());
        tabControl1.TabPages.Add(new TabPage());
        tabControl1.Dock = DockStyle.Fill;
        this.Controls.Add(tabControl1);
    
        // Make long ListView and add to first tab
        ListView listView1 = new ListView();
        listView1.Location = new Point(0, 0);
        listView1.Height = 1000;
        tabControl1.TabPages[0].Controls.Add(listView1);
    
        // Your code
        foreach (TabPage _Page in tabControl1.TabPages)
        {
            _Page.AutoScroll = true;
            _Page.AutoScrollMargin = new System.Drawing.Size(20, 20);
            _Page.AutoScrollMinSize = new System.Drawing.Size(_Page.Width, _Page.Height);
        }
    }
