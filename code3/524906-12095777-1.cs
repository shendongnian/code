    private static bool CompareArray(string[]  arr1, string[] arr2)
    {
            //see the length
            if(arr1.Length != arr2.Length)
            {
                return false;
            }
            //iterate throught it
            foreach( string str in arr1 )
            {
                if(!arr2.Contains( str ))
                {
                    return false;
                }
            }
                return true;
     }
