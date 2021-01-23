    var query = from o in options
                where EqtCodes.Contains(o.EqtCode)
                group o by o.EqtCode into g;
                select g.OrderBy(x => x.Price).First();
     var options = query.ToArray();
     options = query.Length == EqtCodes.Length ? options : new options[0];
