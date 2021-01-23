    var serialNumbers = from sn in code 
                where DateTime.Parse(sn.Substring(sn.Length-8,8)) == new DateTime(2012,8,29)
                group sn by sn.Substring(0, 10) into g 
                        select new { Key = g.Key,  
                                     Cnt = g.Count(),  
                                     Min = g.Min(v => v.Substring(10)),  
                                     Max = g.Max(v => v.Substring(10)) }; 
