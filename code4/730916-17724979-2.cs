    var DesiredSym = 
        (from r in Symptoms
         where r.Status.Equals(1) && r.Create_Date < TimespanSecs  
         select retireMe)
        .Take(5);
    var t = DesiredSym.GetType().GenericTypeArguments[0];
    var props = t.GetProperties().Where(p => p.Name.StartsWith("Month"));
    var sum = DesiredSym.AsEnumerable()
                        .Sum(s => props.Sum(p => (int)p.GetValue(s, null)));
