    namespace CultureFormatting {
      using System;
      using System.Globalization;
    
      class Program {
        public static void Main() {
          Decimal value = -1234567890.1234789012M;
          Print("en-US", value);
          Print("ca-ES", value);
          //print("gws-FR", value);
          Print("fr-CH", value);
          Print("ar-DZ", value);
          Print("prs-AF", value);
          Print("ps-AF", value);
          Print("as-IN", value);
          Print("lo-LA", value);
          Print("qps-PLOC", value);
        }
        static void Print(string cultureName, Decimal value) {
          CultureInfo cultureInfo = new CultureInfo(cultureName);
          string result = 
            String.Format(cultureInfo, "{0,-8} {1:N}", cultureName, value);
          Console.WriteLine(result);
        }
      }
    }
