            string line;
            string fromFile = string.Empty;
            using (StreamReader reader = new StreamReader("D:\\mun.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // add each line read from the file to a temporary string 
                    fromFile +=line;
                }
            }
            richTextBox1.Text = fromFile;
