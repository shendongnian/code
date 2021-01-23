      public void button1_Click(object sender, EventArgs e)
        {
              timer1.Interval = 5000;
              timer1.Enabled = true;
        }
       private void timer1_Tick(object sender, EventArgs e)
       {
            timer1.Enabled = false;  
            // Your actions
       }
