      TabPage tp = new TabPage("New Tabl Page");
         
            TextBox t = new TextBox(); 
            t.Left = 10;
            t.Top = 10;
            t.Visible = true;
            t.Width = 100;
            tp.Controls.Add(t);
            tabControl1.TabPages.Add(tp);
