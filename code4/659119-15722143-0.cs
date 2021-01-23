    var myResult =  (from n in db.Navigation
                         join st in db.SectionTranslations
                         on n.SectionID equals st.Section.SectionID
                         where n.Category == Category && st.CultureID == CultureID
                         orderby n.Position ascending
                         select new
                         {
                              LinkAddress = st.Section.Type + "/" + st.Section.RouteName,
                              st.Title
                          }).ToList();
   
   
    foreach(var item in myResult)
    {
         string linkAddrs = item.LinkAddress;
         string title = item.Title;
    }
