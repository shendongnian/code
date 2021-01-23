    private void button1_Click(object sender, EventArgs e)
    {
        int v;
        v = c++;
        panel1.VerticalScroll.Value = VerticalScroll.Minimum;
        Button btn = new Button();
        btn.Name = "btn" + v;
        btn.Text = "Remove";
        btn.Location = new Point(750, 5 + (30 * v));
        btn.Click += new EventHandler(btn_Click);
        btn.Tag = v;
        ComboBox combo = new ComboBox();
        combo.Name = "combobox" + v ;
        combo.Location = new Point(30, 5 + (30 * v));
        combo.Tag = v;
        ComboBox combo2 = new ComboBox();
        combo2.Name = "combobox2" + v ;
        combo2.Location = new Point(170, 5 + (30 * v));
        combo2.Tag = v;
        TextBox txt = new TextBox();
        txt.Name = "txtbx" + v;
        txt.Location = new Point(300, 5 + (30 * v));
        txt.Tag = v;
        TextBox txt2 = new TextBox();
        txt2.Name = "txtbx2" + v;
        txt2.Location = new Point(450, 5 + (30 * v));
        txt2.Tag = v;
        TextBox txt3 = new TextBox();
        txt3.Name = "txtbx3" + v;
        txt3.Location = new Point(600, 5 + (30 * v));
        txt3.Tag = v;
        panel1.Controls.Add(combo);
        panel1.Controls.Add(btn);
        panel1.Controls.Add(txt);
        panel1.Controls.Add(combo2);
        panel1.Controls.Add(txt2);
        panel1.Controls.Add(txt3);    
    }
    private void btn_Click(object sender, EventArgs e)
    {
        int toBeDeletedRow = (int)((Control)sender).Tag;
        for (int row = panel1.RowCount - 1; row >= 0; row--)
        {
            if (row == toBeDeletedRow)
            {
                panel1.RowStyles.RemoveAt(row);
                panel1.RowCount--;
                return;
            }
        }
    }
