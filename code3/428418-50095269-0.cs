     var retList = (from dbc in db.Companies
                               where dbc.IsVerified && dbc.SellsPCBs && !dbc.IsDeleted && !dbc.IsSpam && dbc.IsApproved
                               select new
                               {
                                   name = dbc.CompanyName,
                                   compID = dbc.CompanyID,
                                   state = dbc.State,
                                   city = dbc.City,
                                   businessType = dbc.BusinessType
                               }).GroupBy(k => k.state).ToList();
                List<dynamic> finalList = new List<dynamic>();
                foreach (var item in retList)
                {
                    finalList.Add(item.GroupBy(i => i.city));
                }
