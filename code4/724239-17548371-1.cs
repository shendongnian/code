    var input = "var buyPrice=[[Date.UTC(2012,0,9),385.250000], [Date.UTC(2012,0,10),386.250000], [Date.UTC(2012,0,11),387.000000]];"
    var regex = @"\[Date.UTC\((?<year>\d{4}),(?<month>\d{1,2}),(?<day>\d{1,2})\),(?<price>\d+(\.\d+)?)]";
    var matches = Regex.Matches(input, regex)
                       .OfType<Match>()
                       .Select(m => new
                           {
                               Date = new DateTime(
                                   Int32.Parse(m.Groups["year"].Value),
                                   Int32.Parse(m.Groups["month"].Value) + 1,
                                   Int32.Parse(m.Groups["day"].Value)
                               ),
                               Price = Decimal.Parse(m.Groups["price"].Value)
                           });
