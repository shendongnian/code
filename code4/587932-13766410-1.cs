    public static List<AllInfo> yourMethodName(Guid eventID)
    {
        using (CyberDBDataContext db = new CyberDBDataContext())
        {
            DataLoadOptions options = new DataLoadOptions();
            options.LoadWith<EventRegistration>(p => p.CyberUser);
            db.LoadOptions = options;
            List<AllInfo> list = (from a in db.EventRegistrations 
                                 where a.EventID == eventID 
                                 select new AllInfo (){ RegisterID = a.RegisterID, 
                                                        EventID = a.EventID,
                                                        UserID = a.UserID,
                                                        UserName = a.User.UserName...}).ToList();
            return list;
        }
}
