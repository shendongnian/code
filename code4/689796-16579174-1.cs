    public void ConsoleEnter_KeyDown(object sender, KeyEventArgs e)
     {
        string line;
        string path = @"C:\\Users\\Home\\Desktop\\commands.txt";
         WebClient client = new WebClient();
	     System.IO.Stream stream = client.OpenRead(path);
	     System.IO.StreamReader str = new StreamReader(stream);
             string Text=str.ReadToEnd();    
             string[] words = Text.Split('\n');   
 
         
          if (e.KeyCode == Keys.Enter)
           {
  
           for(int i=1;i<words.Length;i++)
				{  
                   if (string.compare(words[i],"ConsoleEnter.Text")==0)
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
