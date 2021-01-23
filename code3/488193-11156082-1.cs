    if (!path(folderBrowserDialog1.SelectedPath))
        MessageBox.Show("Please select a folder!");
    else if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text!=""))
    {
        folder = folderBrowserDialog1.SelectedPath;
        maxlinks = int.Parse(textBox1.Text);
        packetlink = int.Parse(textBox2.Text);
        //  apikey = textBox4.Text;
        foreach (string file in Directory.GetFiles(folder))
        {
            int counter = 0;
            string line;
    
            // Read the file and display it line by line.
            System.IO.StreamReader file = 
               new System.IO.StreamReader(file);
            while((line = file.ReadLine()) != null && counter < 30000)
            {
                Console.WriteLine (line);
                counter++;
            }
    
            file.Close();
        }
        
    }
    else
    {
        MessageBox.Show("Please check your input!");
    }
