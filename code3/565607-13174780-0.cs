    IEnumerable<XElement> currRow = q.OrderBy(yyy => (int)yyy.Attribute("t")); 
    
    int xValue = 10;    
    
    var abc = currRow.Where(yyy => (int)yyy.Attribute("t") < xValue);
    //Do something with abc , abc is IEnumerable<XElement> list;
