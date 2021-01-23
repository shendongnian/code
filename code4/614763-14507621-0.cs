            TabPage tp = new TabPage();
            foreach (Control c in this.tabControl1.TabPages[0].Controls)
            {
                Control c1 = null /* ToDo:  clone control c here. */;
                tp.Controls.Add(c1);
                /* ToDo:  You might have to set the bounds of the new control (see article) */
            }
            
            this.tabControl1.TabPages.Add(tp);
