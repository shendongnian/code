    var query = (from s in db.tSearches
            join c in db.tCompanies on s.CompanyGUID equals c.GUID
            join cl in db.tCompanyLocations on s.LocationGUID equals cl.GUID
            join st in db.tSearchTypes on s.SearchTypeGUID equals st.GUID
            where s.DateClosed == null                        
            select new VacancySummary()
            {
                Id = s.GUID,
                Departments = string.Empty,
                Type = st.GUID,
                Location = cl.LocationName,
                Company = (s.Confidential) ? String.Empty : c.CompanyName,
                DateOpened = s.DateOpened,
                Notes = s.PlacementNotes,
                Closed = s.DateClosed != null
            }).ToList();
