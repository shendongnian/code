    var isMobile = (from d in _db.UserDeviceDetail 
                            where ((d.CreatedOn.Month >= fromDate.Month && d.CreatedOn.Day >= fromDate.Day && d.CreatedOn.Year >= fromDate.Year) || (d.CreatedOn.Month <= toDate.Month && d.CreatedOn.Day <= toDate.Day && d.CreatedOn.Year <= toDate.Year)) 
                            select d).ToList(); 
    return new List<IsMobile>(){
                new IsMobile{ 
                    Yes = isMobile.Count(n => n.IsMobile == true), 
                    No = isMobile.Count(n => n.IsMobile == false)}
                };
