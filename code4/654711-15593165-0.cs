    public void Form1()
    {
     //here is code of constructor
     .....
     contextMenuStrip1 = new ContextMenuStrip();
     System.Windows.Forms.ToolStripMenuItem copyStripMenuItem;
     copyStripMenuItem = new ToolStripMenuItem();
     this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
     copyStripMenuItem });
     this.contextMenuStrip1.Name = "contextMenuStrip1";
     this.contextMenuStrip1.Size = new System.Drawing.Size(169, 98);
     copyStripMenuItem.Name = "copyToolStripMenuItem1";
     copyStripMenuItem.Size = new System.Drawing.Size(168, 22);
     copyStripMenuItem.Text = "Copy";
     copyStripMenuItem.Click += new EventHandler(copyStripMenuItem_Click);
			
     dataGridView1.ContextMenuStrip = contextMenuStrip1;
     ....
     }
	
     void copyStripMenuItem_Click(object sender, EventArgs e)
     {
        CellCopy();
     }
     public void CellCopy()
     {
        DataGridViewCell cell = dataGridView1.CurrentCell;
        if (cell != null)
        {
           DataGridViewColumn col = dataGridView1.Columns[cell.ColumnIndex];
                if (col is DataGridViewTextBoxColumn)
                {
                    if (cell.IsInEditMode)
                    {
                        TextBox txt = dataGridView1.EditingControl as TextBox;
                        if (txt != null)
                            txt.Copy();
                    }
                    else
                    {
                        string val = cell.FormattedValue == null ? "" : cell.FormattedValue.ToString();
                        if (val == "")
                            Clipboard.Clear();
                        else
                            Clipboard.SetText(val);
                    }
                }
            }
        }
 
