    DateTime time = DateTime.Now;
    
       private void timer1_Tick(object sender, EventArgs e)
       {
           if (DateTime.Compare(DateTime.Now, time.AddMinutes(10)) > 0)
           {
               timer1.Stop();
           }
           // timer code
       }
