    XElement x = XElement.Load("In.xml");
    IFormatProvider f = new System.Globalization.CultureInfo("en-US");
    DateTime bdate = DateTime.Parse("3/29/2012", f);
    DateTime edate = DateTime.Parse("8/29/2012", f);
    string username = "David";
    var info = x.Elements("User")
                .Where(u => u.Element("Name").Value == username)
                .Select(u => new
    {
      Name = u.Element("Name").Value,                   //user name
      AverageAttempts = u.Elements("Attempts")          //select user's attempts 
                         .Where(a =>                    //filter by dates
                         {
                            DateTime d = DateTime.Parse(a.Element("Date").Value, f);
                            return d >= bdate && d <= edate;
                         })
                         .GroupBy(a => a.Element("Place").Value) //group by place
                         .Select(g => new         // create summary info by place
                         {
                            Place = g.Key,              //place
                            BeginDate = g.Elements("Date") 
                                         .Select(d => DateTime.Parse(d.Value, f))
                                         .Min(),   //min date, i.e. first attempt
                            EndDate = g.Elements("Date")   
                                       .Select(d => DateTime.Parse(d.Value, f))
                                       .Max(),   //max date, i.e. last attempt
                            Distance = g.Elements("Distance")//average distance
                                        .Average(d => decimal.Parse(d.Value))
                         })
    })
    .FirstOrDefault();
    
    if(info!=null)
    {
       Console.WriteLine(info.Name);
       foreach (var aa in info.AverageAttempts)
       {
           Console.WriteLine(string.Format("{0} [{1} - {2}]:\t{3}",
                                           aa.Place,
                                           aa.BeginDate,
                                           aa.EndDate,
                                           aa.Distance));
       }
    }
