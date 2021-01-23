     protected void EntityDataSource1_OnQueryCreated(object sender, QueryCreatedEventArgs e)
            {
                var filters = DomainFilters;
    
                if (filters.Count > 0)
                {
                    e.Query = from view in e.Query.Cast<MAPPING_VIEW>()
                              join bo1 in SecurityContext.MAP_TYPE
                                  on view.MAP_TYPE_ID equals bo1.MAP_TYPE_ID
                              where filters.Contains(bo1.DOMAIN_ID)
                              orderby view.NAME
                              select view;
                }
                else
                {
                    e.Query = from view in e.Query.Cast<MAPPING_VIEW>()
                              orderby view.NAME
                              select view;
                }
            }
