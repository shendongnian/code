    public void ConsoleEnter_KeyDown(object sender, KeyEventArgs e)
     {
        string line;
        string path = @"C:\\Users\\Home\\Desktop\\commands.txt";
         WebClient client = new WebClient();
	     System.IO.Stream stream = client.OpenRead(path);
	     System.IO.StreamReader str = new StreamReader(stream);        
         
          if (e.KeyCode == Keys.Enter)
           {
  
            while ((str.ReadToEnd()) != null)
            {
                 while ((line = str.ReadLine()) != null)
                {   
                   if (line.Contains(ConsoleEnter.Text))
                  {
                    COMBOX.Items.Add(ConsoleEnter.Text);
                    COMBOX.Items.Remove("");
                    ConsoleEnter.Text = "";
                   }
                else
                 {
                    COMBOX.Items.Add("Invalid Command");
                    COMBOX.Items.Remove("");
                    ConsoleEnter.Text = "";
                 }
              }
            }
        }
    }
