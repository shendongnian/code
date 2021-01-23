    public static class Utilities{
        public static string[][] MultipleSplit(this string s, char[] c){
             string[][] result = new string[c.Length][];
             for(int i = 0; i < c.Length; i++)
                  result[i] = s.Split(c[i]);
              
             return result;
        }
    }
