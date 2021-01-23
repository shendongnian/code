    var DesiredSym = 
        from r in Symptoms
        where r.Status.Equals(1) && r.Create_Date < TimespanSecs  
        select retireMe;
    // first method
    var batchSums = DesiredSym.Batch(5, b => b.Sum(s => s.Month1_Use ...)); 
    // second method
    var t = DesiredSym.GetType().GenericTypeArguments[0];
    var props = t.GetProperties().Where(p => p.Name.StartsWith("Month"));
    var batchSums = DesiredSym.Batch(5, b => b.Sum(s => props.Sum(p => (int)p.GetValue(s, null)))); 
