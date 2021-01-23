    var tbl = xdoc.SelectNodes("//table[2]//tr[4]//td[position()>1]");
    // In order to select the 1st table, the following statement can be used.
    //var tbl = xdoc.SelectNodes("//table[2]//tr[4]//td[position()>1]");
    int sum = 0;
    foreach (XmlNode item in tbl) 
    {
         decimal value = 0;
         if (decimal.TryParse(item.InnerText, out value))
         {
             sum += (int)value;
         }
     }
     Console.WriteLine("Number of (Web Application) sites: " + sum);
