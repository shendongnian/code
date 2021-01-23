    private Panel createPanels(int gridX, int gridY)
    {
        Label lbl = lbl_grid[gridX,gridY];
        Button btn = btn_grid[gridX,gridY];
        Panel pnl = new Panel();
        pnl.Name = gridX.ToString() + " " + gridY.ToString();
        //pnl.Text = "0";
        pnl.Size = new System.Drawing.Size(30, 30);
        //lbl.Font = new Font("Microsoft Sans Serif", 15.75f, lbl.Font.Style, lbl.Font.Unit);
        pnl.Controls.AddRange(new System.Windows.Forms.Control[] { lbl,btn });
        lbl.Dock = DockStyle.Top;
        btn.Dock = DockStyle.Fill;
        return pnl;
    }
