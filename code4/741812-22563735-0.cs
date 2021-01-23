    Table tb = new Table();
                       
    for (int i = 1; i <= 10; i++)
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                Button bt = new Button();
                bt.ID = i.ToString();
                bt.Text = "Button " + i.ToString();
                bt.Click += new EventHandler(btn_Click);
                td.Controls.Add(bt);
                tr.Controls.Add(td);
                tb.Controls.Add(tr);
            }
            
    dvTest.Controls.Add(tb);
