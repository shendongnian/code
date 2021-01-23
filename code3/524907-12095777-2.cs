    private List<string> CompareArray(string[]  arr1, string[] arr2)
    {
            List<string> compareList = new List<string>();
            //iterate throught it
            foreach( string str in arr1 )
            {
                if(!arr2.Contains( str ))
                {
                    compareList.Add(str);
                }
            }
                return compareList;
     }
