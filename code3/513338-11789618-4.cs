      static void Main()
      {
         double y = 1.23456;
         Console.WriteLine(FormatNumDigits(y,5));
         y= -12.34567;
         Console.WriteLine(FormatNumDigits(y,5));
         y = -0.123456;
         Console.WriteLine(FormatNumDigits(y,5));
         y = 1234.567;
         Console.WriteLine(FormatNumDigits(y,5));
         
         y = 0.00000234;
         Console.WriteLine(FormatNumDigits(y,5));
         y = 1.1;
         Console.WriteLine(FormatNumDigits(y,5));
      }
      public string FormatNumDigits(double number, int x) {
         string asString = (number >= 0? "+":"") + number.ToString("F50",System.Globalization.CultureInfo.InvariantCulture);
         if (asString.Contains('.')) {
            if (asString.Length > x + 2) {
               return asString.Substring(0, x + 2);
            } else {
               // Pad with zeros
               return asString.Insert(asString.Length, new String('0', x + 2 - asString.Length));
            }
         } else {
            if (asString.Length > x + 1) {
               return asString.Substring(0, x + 1);
            } else {
               // Pad with zeros
               return asString.Insert(1, new String('0', x + 1 - asString.Length));
            }
         }
      }
    
