    var result = from c in allCompanies 
                 select new { c.LastName, c.FirstName, c.Phone, c.City, 
                 c.PositionApplied, c.Status, 
                 CallDate = Convert.ToString(c.CallDate.Value.ToShortDateString()), 
                 CellOrPager = Convert.ToString(c.CellOrPager), c.Gender };
