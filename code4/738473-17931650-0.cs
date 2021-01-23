        public IEnumerable<ContentVw> GetSections()
        {
            using (var db = my connection info)
            {
                return (from e in db.Table1
                                join re in db.RootTables re
                                on e.ID equals re.Table1ID
                                where re.ChairID == 1                                
                                select new ContentVw { Name = e.DisplayName, // here you get ContentVw  objects
                                                       Id = e.ID,
                                                       GUID = e.GUID }).ToList();
            }
        }
