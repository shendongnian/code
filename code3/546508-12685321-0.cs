    public string GetData(string userName, DateTime fromDate, DateTime toDate)
    {
         var userElement = xDox.Descendants("User")
                .SingleOrDefault(u => u.Element("Name").Value == userName);
    
        var builder = new StringBuilder();
    
        if (userElement != null)
        {
            var result = userElement.Descendants("Attempts")
                .Select(a => new
                    {
                        Place = a.Element("Place").Value,
                        Date = DateTime.Parse(a.Element("Date").Value),
                        Distance = int.Parse(a.Element("Distance").Value)
                    })
    
                .Where(a => a.Date >= fromDate
                            && a.Date <= toDate)
    
                .GroupBy(a => a.Place)
                .Select(g => new {Place = g.Key, Avg = g.Average(x => x.Distance)});
    
            builder.AppendFormat("User:{0}", userName);
            builder.AppendLine();
    
            builder.AppendFormat("Date:{0} to {1}", fromDate, toDate);
            builder.AppendLine();
    
            foreach (var item in result)
            {
                builder.AppendFormat("Average Distance in {0}: {1}", r.Place, r.Avg);
                builder.AppendLine();
            }
        }
    
        return builder.ToString();
    }
