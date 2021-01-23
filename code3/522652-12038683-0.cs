            spanList[i] = TimeSpan.Parse(s);
            total=total.Add(spanList[i++]);
 }
    
        Response.Write("Max TimeSpan:"+spanList.Max<TimeSpan>());
        Response.Write("Min TimeSpan:" + spanList.Min<TimeSpan>());
        Response.Write("Total Sum of TimeSpan:"+total);
