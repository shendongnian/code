            string line = null;
            System.IO.TextReader readFile = new StreamReader("...."); //Adjust your path
            while (true)
            {
                line = readFile.ReadLine();
                if (line == null)
                {
                    break;    
                }
                MessageBox.Show (line);
            }
            readFile.Close();
            readFile = null;
