        private void button1_Click(object sender, EventArgs e)
        {
            // create new tab
            TabPage tp = new TabPage();
            // iterate through each control and clone it
            foreach (Control c in this.tabControl1.TabPages[0].Controls)
            {
                // clone control (this references the code project download ControlFactory.cs)
                Control ctrl = CtrlCloneTst.ControlFactory.CloneCtrl(c);
                // now add it to the new tab
                tp.Controls.Add(ctrl);
                // set bounds to size and position
                ctrl.SetBounds(c.Bounds.X, c.Bounds.Y, c.Bounds.Width, c.Bounds.Height);
            }
            
            // now add tab page
            this.tabControl1.TabPages.Add(tp);
        }
