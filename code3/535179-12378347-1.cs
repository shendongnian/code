    private void btnClick(object sender, EventArgs e) 
    {  
       if(Properties.Settings.Default.Properties.Count != 0)
       {
          int Counter = 0;
          foreach (SettingsProperty currrentProperty in Properties.Settings.Default.Properties)
          {
             Counter++;
             //Some stuff here else just use .Count without use a foreach
          }
          lblText.Text = Counter.ToString();
       } 
       else
          throw new Exception("Properties.Settings.Default.Properties is empty");
    }
