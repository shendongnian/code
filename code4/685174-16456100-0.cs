      public Show_hideControl()
            {
                InitializeComponent();
    
                //Adding First User control
                Main _main = new Main();        
    
                panel1.Controls.Add(_main);
    
             
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //removing already added user control
              panel1.Controls.Clear();            
           //Adding second user control
              Alternative _alter = new Alternative();
              panel1.Controls.Add(_alter);
             
            }
