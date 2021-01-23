    public IEnumerable<ContentVw> GetSections()
    {
        using (var db = my connection info)
        {
            var sections = from e in db.Table1
                           join re in db.RootTables re
                           on e.ID equals re.Table1ID
                           where re.ChairID == 1
                           select new ContentVw
                               {
                                   Name = e.DisplayName,
                                   Id = e.ID,
                                   GUID = e.GUID
                               };
                                           
            return sections;
        }
    }
    public IEnumerable<ContentVw> GetContent(int itemId) //itemId = first dropdown list selection
    {
        using (var db = my connection info)
        {
            var content = (from e in db.Table1
                           join em in db.TableToTableMaps
                           on e.ID equals em.KnowsTableID
                           where em.TableID == itemId
                           select new ContentVw
                               {
                                   Name = e.DisplayName,
                                   Id = e.ID,
                                   GUID = e.GUID
                               });
                               
            return content;
        }
    }
