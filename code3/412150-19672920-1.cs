    using (StreamReader r = new StreamReader("C:\\Projects\\Mactive\\Audience\\DrawBalancing\\CSVFiles\\Analytix_ABC_HD.csv"))
    {
         string row;
         int outCount;
             StringBuilder line=new StringBuilder() ;
             string token="";
             char chr;
             string Eachline;
               
         while ((row = r.ReadLine()) != null)
         {
             outCount = row.Length;
             line = new StringBuilder();
             for (int innerCount = 0; innerCount <= outCount - 1; innerCount++)
             {                   
                 chr=row[innerCount];
                 if (chr != '"')
                 {
                     line.Append(row[innerCount].ToString());
                 }
                 else if(chr=='"')
                 {
                     token = "";
                     innerCount = innerCount + 1;
                     for (; innerCount < outCount - 1; innerCount++)
                     {
                         chr=row[innerCount];
                         if(chr=='"')
                         {
                             break;
                         }
                         token = token + chr.ToString();                               
                     }
                     if(token.Contains(",")){token=token.Replace(",","");}
                     line.Append(token);
                 }                 
             }
             Eachline = line.ToString();
             Console.WriteLine(Eachline);
        }
    }
