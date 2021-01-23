    public static int getStringIdentifier(string str)
    {
       int result = 0;
       foreach (char c in str) {
         result += (int)c;
       }
       return result;
    }
