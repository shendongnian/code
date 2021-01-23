        private UserControl1 us1;
        private UserControl1 us2;
            
        private void button1_Click(object sender, EventArgs e)
        {
            int v;
            v = c++;
            panel1.VerticalScroll.Value = VerticalScroll.Minimum;
            
            if(us == null) 
            {
                //this is the first time the control is created
                us1 = new UserControl1();
                us1.Name = "us" + v;
                us1.Location = new Point(50, 5 + (30 * v));
                us1.Tag = btn;        
                panel1.Controls.Add(us1);
            }
            else if(us2 ==null)
            {
                us2 = new UserControl1();
                //whatever code you want to execute to change second one
                //you can access first control as us1.xxx
                panel1.Controls.Add(us2);
                
            }
            else
            {
               //3rd 4th etc...
            }
            
         }
