       internal static List<string> GetAllSubstring(String mainString)
        {
            try
            {
                var stringList = new List<string>();
                if(!string.IsNullOrEmpty(mainString))
                {
                    for (int i = 0; i < mainString.Length; i++) //i is starting position
                    {
                        for (int j = 2; j + i < mainString.Length; j++) //j is number of characters to get
                        {
                            if(!stringList.Contains(mainString.Substring(i, j)))
                            {
                                stringList.Add(mainString.Substring(i, j));
                            }
                        }
                    }
                }
                return stringList;
            }
            catch(Exception ex)
            {
            }
            return null;
        }
