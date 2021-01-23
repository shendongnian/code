    public static bool CheckForNum(string[] wordsArr)
    {
         int i = 0;
         foreach (string s in wordsArr)
         {
             if (Int32.TryParse(s, out i))
             {
                 return true;
             }
         }
         return false;
     }
