    TableLayoutPanel tlp = new TableLayoutPanel();
    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
    tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
    
    TextBox b1 = new TextBox(); b1.Dock = DockStyle.Fill;
    TextBox b2 = new TextBox(); b2.Dock = DockStyle.Fill;
    TextBox b3 = new TextBox(); b3.Dock = DockStyle.Fill;
    CheckBox special = new CheckBox(); special.Text = "Special?";
    TextBox b4 = new TextBox(); b4.Dock = DockStyle.Fill; b4.Visible = false;
    TextBox b5 = new TextBox(); b5.Dock = DockStyle.Fill; b5.Visible = false;
    Button button = new Button(); button.Text = "Save";
    
    special.CheckedChanged += new EventHandler((sender, args) => { b4.Visible = b5.Visible = special.Checked; });
    
    tlp.Controls.Add(b1, 0, 0);
    tlp.Controls.Add(b2, 0, 1);
    tlp.Controls.Add(b3, 0, 2);
    tlp.Controls.Add(special, 0, 3);
    tlp.Controls.Add(b4, 0, 4);
    tlp.Controls.Add(b5, 0, 5);
    tlp.Controls.Add(button, 0, 6);
    
    Controls.Add(tlp);
    tlp.Dock = DockStyle.Fill;
    tlp.BringToFront();
