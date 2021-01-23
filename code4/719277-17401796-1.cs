    using(var fs = File.Create(@"W:\SRC\hDefML\myExcelFile.csv"))
    {
       using (StreamWriter sw = new StreamWriter(fs))
       {
          sw.Write(sb.ToString());                  
       }
    }
