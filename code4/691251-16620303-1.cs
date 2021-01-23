      timeX.Interval = 500;
    
    ...
    
    
      TimeSpan timeSpan = TimeSpan.FromMinutes(30);
      DataTime startedAt = DateTime.Now;
      void timeX_Tick(object sender, EventArgs e)
      { 
           if ((DateTime.Now - startedAt)<timeSpan){
              Invoke(()=>{
                 TimeSpan remaining = timeSpan - (DateTime.Now - startedAt);
                 textBox.Text = remaining.ToString(); 
              });
           } else
              timeX.Stop();
      }
