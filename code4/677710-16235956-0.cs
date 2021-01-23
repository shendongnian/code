    public void CalculateManhattanDistance(Dictionary<int, List<string>> MissingList, Dictionary<int, List<string>> OtherList)
        {
            Dictionary<int,Array> MissingListNeighbours = new Dictionary<int,Array>();
            Dictionary<int, List<int>> ManhattanDistanceList = new Dictionary<int,List<int>>();
               
            try
            {
                for (int i = 0; i < MissingList.Count(); i++)
                {
                    List<int> tempList = new List<int>();
                    for (int j = 0; j < OtherList.Count(); j++)
                    {
                        int total=0;
                        for (int k = 0; k < MissingList[0].ToArray().Length; k++)
                        {
                            if (Convert.ToChar(MissingList[i][k].ToString()) == '?')
                                continue;
                            else
                                total += Math.Abs(Convert.ToInt32(MissingList[i][k].ToString()) - Convert.ToInt32(OtherList[j][k].ToString()));
    
    
                        }
                        tempList.Add(total);
    
                    }
                    ManhattanDistanceList.Add(i, tempList);
    
                }
            }
            catch (Exception ex)
            {
                  ex.Message.ToString();
            }
        }
