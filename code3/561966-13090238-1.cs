    private void button1_Click(object sender, EventArgs e)
            {
                List<string[]> strs = new List<string[]>();
                strs.Add(new string[] {"Buildings"});
                strs.Add(new string[] {"Facilities"});
                strs.Add(new string[] {"Fields"});
                strs.Add(new string[] {"Files", "Groups", "Entity"});
                strs.Add(new string[] {"Controllers", "FX", "Steam"});
                List<string> list = AddStringsToList(strs, 0);
                
            }
    
            List<string> AddStringsToList(List<string[]> list, int level)
            {
                List<string> listOfStrings = new List<string>();
                if (level == list.Count - 1)
                {
                    foreach (string s in list[level])
                    {
                        listOfStrings.Add(s);
                    }
                }
                else if(level<list.Count-1)
                {
                    List<string> list1 = AddStringsToList(list, level + 1);
                    foreach (string s in list[level])
                    {
                        foreach(string s1 in list1)
                            listOfStrings.Add(s + "---" + s1);
                    }
                }
                return listOfStrings;
            }
