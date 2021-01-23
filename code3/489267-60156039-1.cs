                List<set> Sets = new List<set>();
                string textfile = "your text file";
                char[] spliter = new char[] { ',' };  //switch that , to whatever you want but this will split whole textfile into fragments of sets
                List<string> files = textfile.Split(spliter).ToList<string>();
                int i = 1;
                foreach (string file in files)
                {
                    set set = new set();
                    set.ID = i.ToString();
    
                    char[] secondspliter = new char[] { ',' };  //switch that , to whatever you want but this will split one set into lone numbers
                    List<string> data = textfile.Split(secondspliter).ToList<string>();
                    foreach (string number in data)
                    {
                        bool success = Int32.TryParse(number, out int outcome);
                        if (success)
                        {
                            set.numbers.Add(outcome);
                        }
                        
                    }
                    i++;
                    Sets.Add(set);
                }
    
            
