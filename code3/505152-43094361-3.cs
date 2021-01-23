    private string remEscChars(string str)
    {
       int pos = 0;
       string subStr = null;
       string escStr = null;
    
       try
       {
          while ((pos = str.IndexOf(@"\x")) >= 0)
          {
             subStr = str.Substring(pos + 2, 2);
             escStr = Convert.ToString(Convert.ToChar(Convert.ToInt32(subStr, 16)));
             str = str.Replace(@"\x" + subStr, escStr);
          }
       }
       catch (Exception ex)
       {
          throw ex;
       }
       return str;
    }
