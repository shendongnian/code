        private UserControl us;
            
        private void button1_Click(object sender, EventArgs e)
        {
            int v;
            v = c++;
            panel1.VerticalScroll.Value = VerticalScroll.Minimum;
            
            if(us == null) 
            {
                //if the control has not been created yet then create it
                us = new UserControl1();        
                panel1.Controls.Add(us);
            }
            us.Name = "us" + v;
            us.Location = new Point(50, 5 + (30 * v));
            us.Tag = btn;
            //you might have to refresh the view of the panel if the values don't update
            //panel1.Refresh();
         }
