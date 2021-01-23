    var query = from d in data
               group d by new { d.DateIssued, d.EmpId, d.ChNo, d.DateReceived }
    		   into x
               select new {
                    Date = x.Key.DateIssued,
                    CNo = x.Key.ChNo,
    				EmpId=x.Key.EmpId,
    				CRi = x.Where(c=>c.RMIssued == "CR").Sum(c=>c.QuantityIssued),
    				SJi = x.Where(c=>c.RMIssued == "SJ").Sum(c=>c.QuantityIssued),
    				TTi = x.Where(c=>c.RMIssued == "TT").Sum(c=>c.QuantityIssued),
    				WRi = x.Where(c=>c.RMIssued == "WR").Sum(c=>c.QuantityIssued),
                    TotalIssued = x.Sum(c => c.QuantityIssued),
    
                    DateReceived = x.Key.DateReceived,
    				CRr = x.Where(c=>c.RMCodeReceived == "CR").Sum(c=>c.QuantityReceived),
    				SJr = x.Where(c=>c.RMCodeReceived == "SJ").Sum(c=>c.QuantityReceived),
    				TTr = x.Where(c=>c.RMCodeReceived == "TT").Sum(c=>c.QuantityReceived),
    				WRr = x.Where(c=>c.RMCodeReceived == "WR").Sum(c=>c.QuantityReceived),
                    TotalReceived = x.Sum(c => c.QuantityReceived),
    				
    				Diff = x.Sum(c => c.QuantityIssued) - x.Sum(c => c.QuantityReceived)
    			};
