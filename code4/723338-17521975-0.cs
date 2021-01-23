    var players = from p in myEntity.Players.AsEnumerable()                      
                  where GetGregorianDate(p.ContractDateTo) <= DateTime.Now
                  select new { 
                      p.Name,
                      p.BearthDate, 
                      p.ContractNumber, 
                      p.InsuranceNumber, 
                      p.ContractDate, 
                      p.Mobile 
                  };
