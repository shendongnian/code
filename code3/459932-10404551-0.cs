    public Form1()
    {
        InitializeComponent();
    
        panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
        panel2.AllowDrop = true;
        panel2.DragEnter += new DragEventHandler(panel2_DragEnter);
        panel2.DragDrop += new DragEventHandler(panel2_DragDrop);
    }
    
    void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        panel1.DoDragDrop(panel1, DragDropEffects.Move);
    }
    
    void panel2_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetData(typeof(Panel)) != null) e.Effect = DragDropEffects.Move;
    }
    
    void panel2_DragDrop(object sender, DragEventArgs e)
    {
        Panel p = sender as Panel;//Not needed in this case. Could just write panel2.
        Panel dropped = (Panel)e.Data.GetData(typeof(Panel));
        dropped.Location = p.PointToClient(new Point(e.X, e.Y));
        p.Controls.Add(dropped);
    }
