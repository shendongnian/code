    using System;
    using System.Globalization;
    using System.Threading;
 
      public class FilterString{
        public static void Main(string[] args)
        {
          CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
          TextInfo textInfo = cultureInfo.TextInfo;
            
          string textBoxText = "tEsting To upPerCasE 'STAYCAPS'";
          string filterdTextForLabel = textInfo.ToTitleCase(textBoxText) ;
          Console.WriteLine(filterdTextForLabel);
       
       }
    }   
