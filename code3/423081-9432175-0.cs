                using(StreamReader reader = new StreamReader(Path))
                {
                    string line =  reader.ReadLine();
                    while(line != null)
                    {
                        textBox1.Text += line;
                        line = reader.ReadLine()
                    }
                    reader.Close();
                }
