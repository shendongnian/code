           private void extrcat()
           {
                char[] delimiters = new char[] { '\r', '\n' };
                using (StreamReader reader = new StreamReader(@"C:\Users\Zia\Desktop\input.txt"))
                {
                    string words = reader.ReadToEnd();
                    string[] lines = words.Split(delimiters);
                    foreach (var item in lines)
                    {
                        foreach (var i in findItems(item))
                        {
                            if (i != " ")
                                Console.WriteLine(i);
                        }
                    }
    
                }
            
            }
            private static List<string> findItems(string item)
            {
                List<string> items = new List<string>();
                if (item.Length <= 0)
                {
                    items.Add(" ");
                }
                else
                {
                    List<string> names = new List<string>();
                    string temp = item.Substring(0, item.IndexOf("#") + 2);
                    temp = temp.Replace("\t", ",");
                    temp = temp.Replace("\\t", ",");
    
    
                    items.Add(temp);
                    names = item.Split(' ').Where(x => x.Contains('#')).ToList();
                    int i = 1;
                    while (i < names.Count)
                    {
                        temp = items[0].Substring(0, items[0].LastIndexOf(',')+1) + names[i];
                        items.Add(temp);
                        i++;
                    }
                }
              
                return items;
               
            }
