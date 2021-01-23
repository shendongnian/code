      TextWriter tw = new StreamWriter("D:\\output.txt");    
      private void button1_Click(object sender, EventArgs e)
      {
            StreamReader reader = new StreamReader(@"C:\Users\Mohsin\Desktop\records.txt");
            string line;
            String lines = "";
            while ((line = reader.ReadLine()) != null)
            {
                String[] str = line.Split('\t');
                String[] words = str[3].Split(' ');
                for (int k = 0; k < words.Length; k++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i + 1 != 4)
                        {
                            lines = lines + str[i] + "\t";
                        }
                        else
                        {
                            lines = lines + words[k] + "\r\n";
                        }
                    }
                }
            }
            tw.Write(lines);
            tw.Close();
            reader.Close();
      }
