    public List<string> profile(int phonenumber)
    {
        ToPiDataContext db = new ToPiDataContext();
        var query = (from m in db.lbl_Accounts
                     from n in db.lbl_Profiles
                     where m.AccountID == n.AccountID && m.Phonenumber == phonenumber
                     select new
                     {
                         n.AccountID
                     }).First();
    
        var profile = (from m in db.lbl_Profiles
                       where m.AccountID == query.AccountID
                       select m).First();
        List<string> lst = new List<string>();
        lst.Add(profile.FirstName);
        lst.Add(profile.LastName);
        lst.Add(profile.Location);
        lst.Add(profile.Genre);
        return lst;
    
    }
