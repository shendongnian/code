    var lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/files/file.txt");
    
                Regex reg = new Regex("333333");
                string str;
                for(int i =1; i<lines.Length;i++)
                {
                    str = lines[i];
                    Match sat = reg.Match(str);
                    if (sat.Success)
                    {
                        richTextBox1.Text += (i + 1 +"                    "); //shows index where 333333 is
                        
                    }
                }
