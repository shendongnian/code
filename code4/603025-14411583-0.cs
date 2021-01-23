     public void xref_LoadIntoSessionCache()
             {
                 MyDatabaseEntities ctb = new MyDatabaseEntities();
                 List<XRef_Codes> allCodes = (from x in ctb.XRef_Codes
                            orderby x.OfCodeID, x.SetAsDefault descending, x.SortOrder
                            where (x.IsImplemented == true)
                            select x).ToList();
                 HttpContext.Current.Session["ListOfCodes"] = allCodes;
             }
