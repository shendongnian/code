        var stuff = dg.Stuffs.Where(c=> c.admin !=1).ToList();
                    for (int i = 0; i < stuff.Count; i++)
                    {
                        string test = stuff.ElementAt(i).Name;
                        comboBox1.Items.Add(test);
 
                    }
