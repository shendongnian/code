    private void Form1_Load(object sender, EventArgs e)
    {
         foreach (Control ctrl in this.Controls)
         {
              PropertyInfo[] properties = ctrl.GetType().GetProperties();
              foreach(PropertyInfo pi in properties)
                  if (pi.Name == "Text")
                  { 
                        //has text
                  }
           }
    
    }
