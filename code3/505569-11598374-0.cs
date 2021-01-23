       string location1 = textBox2.Text;
        string text  = String.Empty;
        using (TextReader reader = File.OpenText(location1 ))
        {
               do
               {
        	   string line = reader.ReadLine();
                   text+=line;
                }
                while(line!=null)
        	 
        }
