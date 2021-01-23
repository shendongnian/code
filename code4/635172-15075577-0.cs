                Hashtable tagCloud = new Hashtable();
                ArrayList frequency = new ArrayList();
                
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
                //Storing occurrence of each word.
                List<string> listOfWords = new List<string>(words);
                foreach (string i in listOfWords)
                {
                    int c = 0;
                    foreach (string j in words)
                    {
                        if (i.Equals(j))
                            c++;
                    }
                    frequency.Add(c);
                }
                //Value will be the word. eg: sunny and key will be its occurrence eg:4 
                for (int i = 0; i < listOfWords.Count; i++)
                {
                    //use dictionary here
                    tagCloud.Add(listOfWords[i], (int)frequency[i]);
                }
