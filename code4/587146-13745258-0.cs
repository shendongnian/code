    var list = xDoc.Descendants("item").Select(n => new
    {
        Point = new Point()
        {
           Min = n.Min,
           Max = n.Max,
        }
    });
