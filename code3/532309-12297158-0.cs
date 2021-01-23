            string formattedString = "[l=9;f=0;r=5;p=2],[l=9;f=0;r=6;p=2]";
            var splitString = formattedString.Split(',')
                                        .Select(p => p.Trim(new char[]{'[',']',' '}));
            List<Tuple<int, int, int, int>> tupleList = new List<Tuple<int, int, int, int>>();
            foreach (var item in splitString)
            {
                int[] finalSplit = item.Split(';').Select(p => 
                                                          Convert.ToInt32(p.Substring(p.LastIndexOf('=')+1).Trim())
                                                          ).ToArray();
                tupleList.Add(new Tuple<int, int, int, int>(finalSplit[0], finalSplit[1],
                                        finalSplit[2], finalSplit[3]));
            }
    
