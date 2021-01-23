     string[] lines = File.ReadAllLines("file.txt");
                //use the specific delimiter
                char[] delimiter = new char[] { ' ' };
                StringBuilder buffer = new StringBuilder();
                foreach (string line in lines)
                {
                    if (line.ToString().Length != 0)
                    {
                        buffer.Append((" " + line.Trim()));
                    }
                }
                string[] words = buffer.ToString().Trim().Split(delimiter);
