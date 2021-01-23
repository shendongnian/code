    TableLayoutPanel tlp = new TableLayoutPanel()
                           {
                               RowCount = 2,
                               ColumnCount = 3,
                               ColumnStyles = {
                                   new ColumnStyle(SizeType.AutoSize),
                                   new ColumnStyle(SizeType.Absolute, buttonWidth),
                                   new ColumnStyle(SizeType.AutoSize)
                               }
                           };
    tlp.Controls.Add(groupBox1, 0, 0);
    tlp.Controls.Add(button1, 1, 0);
    tlp.Controls.Add(button2, 1, 1);
    tlp.Controls.Add(groupBox2, 2, 0);
    
    tlp.SetRowSpan(groupBox1, 2);
    tlp.SetRowSpan(groupBox2, 2);
