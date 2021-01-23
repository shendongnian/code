    public Form1()
    {
      InitializeComponent();
      // Example Item
      listBox1.Items.Add("c:\\Folder1\\example1.abc");
      listBox1.Items.Add("c:\\Folder1\\example2.abc");
      listBox1.Items.Add("c:\\Folder1\\example3.abc");
      listBox1.Items.Add("c:\\Folder1\\example4.abc");
      listBox1.Items.Add("c:\\Folder1\\example5.abc");
      listBox1.Items.Add("c:\\Folder1\\example6.abc");
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
      
      // Draw items
      e.DrawBackground();
      e.DrawFocusRectangle();
      e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, SystemBrushes.WindowText, e.Bounds.Location);
      // Transparence
      // 255 = Full Visible
      //  0  = Invisible
      Color clr = Color.FromArgb(20, Color.Red);
      // Modify the position, font and Brush to your need
      e.Graphics.DrawString(ext, SystemFonts.DefaultFont, new SolidBrush(clr), new PointF(200F, 200F));
    }
