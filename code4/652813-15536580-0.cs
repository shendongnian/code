    List<Label> lbls = new List<Label>();
    private void create()
    {
        flowLayoutPanel1.Controls.Clear();
        //int length = ds.Tables[0].Rows.Count;
        for (int i = 0; i < 5; i++)
        {
            lbl = new Label();
            lbl.Name = i.ToString();
            lbl.Text = "Label "+i;
            lbl.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            lbl.SetBounds(0, 20, 100, 25);
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbls.Add(lbl);   //< -- add the label to the local list of Labels
            flowLayoutPanel1.Controls.Add(lbl);
            
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        Export ep = new Export(true);
        foreach(var lbl in lbls)
        {
            i++;
            ep.AddNames(i,0,lbl);
        }
    }
---
    public void AddNames(int row, int col, System.Windows.Forms.Label lbl)
    {
    if (lbl == null) return;
    row++;
    col++;
    Range range = worksheet.Cells[row + 2, col + 2];
    range.NumberFormat = "";
    worksheet.Cells[row + 2, col + 2] = lbl.Text;
    row--;
    col--;
    
    }
