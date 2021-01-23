    ListView lvFiles= new ListView();
    public Form1()
    {
       InitializeComponent();
    
       lvFiles.View = View.Details;
       lvFiles.OwnerDraw = true;
       lvFiles.Size = new Size(200, 100);
    
       lvFiles.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lv_DrawColumn Header);
       lvFiles.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
    
       lv.Columns.Add("Col1");
       lv.Columns.Add("Col1");
       lv.Columns.Add("Col1");
    
       this.Controls.Add(lv);
    
       lv.Items.Add(new ListViewItem(new string[] { "One", "Two","Three" }));
       lv.Items.Add(new ListViewItem(new string[] { "One", "Two","Three" }));
       lv.Items.Add(new ListViewItem(new string[] { "One", "Two","Three" }));
    }
    
    void lv_DrawSubItem(object sender, DrawListViewSubItemEventArgse)
    {
       if ((e.ItemState & ListViewItemStates.Focused) 0)
       {
          e.Graphics.FillRectangle(SystemBrushes.Highlight,e.Bounds);
          e.Graphics.DrawString(e.Item.Text, lv.Font,SystemBrushes.HighlightText, e.Bounds);
       }
       else
       {
          e.DrawBackground();
          e.DrawText();
       }
    }
    
    void lv_DrawColumnHeader(object sender,DrawListViewColumnHeaderEventArgs e)
    {
       e.Graphics.FillRectangle(Brushes.GreenYellow, e.Bounds);
       e.DrawText();
    }
