    public static string hex2Octal(string hexvalue)
       {
          string binaryval = "";
          binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 8);
          return binaryval;
       }
