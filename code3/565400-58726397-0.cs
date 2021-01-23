    static public class StringHelper
    {
      static public bool TryParseEndAsLong(this string str, out long result)
      {
        result = 0;
        if ( string.IsNullOrEmpty(str) )
          return false;
        int index = str.Length - 1;
        for ( ; index >= 0; index-- )
        {
          char c = str[index];
          bool stop = c == '+' || c == '-';
          if ( !stop && !char.IsDigit(c) )
          {
            index++;
            break;
          }
          if ( stop )
            break;
        }
        return index <= 0 ? long.TryParse(str, out result)
                          : long.TryParse(str.Substring(index), out result);
      }
    } 
    
