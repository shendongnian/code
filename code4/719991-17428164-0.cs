    public Form1()
    {
        InitializeComponent();
        // Example Item
        listBox1.Items.Add("c:\\Folder1\\example.abc");
        // Without this listBox1.DrawItem won't fire
        listBox1.DrawMode = DrawMode.OwnerDrawVariable;
        // Subscribe event
        listBox1.DrawItem += listBox1_DrawItem;
    }
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        // Make sure listbox contains items
        if (listBox1.Items.Count == 0)
            return;
        // In this example ext will be ".abc"
        string ext = Path.GetExtension(listBox1.Items[0].ToString());
        // Modify the position, font and Brush to your need
        e.Graphics.DrawString(ext, SystemFonts.DefaultFont, Brushes.Red, new PointF(50f, 50f));
    }
