            TableLayoutPanel t = new TableLayoutPanel();
            t.AutoSize = true;    //added
            t.AutoSizeMode =AutoSizeMode.GrowAndShrink;    //added
            t.RowCount = 1;  //added
            t.ColumnCount = 1;   //added
            t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            t.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Label lbl = new Label();
            lbl.Margin = new System.Windows.Forms.Padding(20, 150, 20, 20);
            lbl.Text = "Hello";
            t.Controls.Add(lbl, 0, 0);
            this.Controls.Add(t);
            this.Text = t.Size.Height.ToString();  //moved
