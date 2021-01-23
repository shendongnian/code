    var selectionDate = new DateTime(2012,8,29);
    var serialNumbers = from sn in code 
                where DateTime.Parse(
                             sn.Trim().Substring(sn.Trim().Length-8,8), 
                             new DateTimeFormatInfo {ShortDatePattern="dd/MM/yy"}) == 
                                  selectionDate;
                 group sn by sn.Substring(0, 10) into g 
                 select new { Key = g.Key,  
                              Cnt = g.Count(),  
                              Min = g.Min(v => v.Substring(10)),  
                              Max = g.Max(v => v.Substring(10)) }; 
