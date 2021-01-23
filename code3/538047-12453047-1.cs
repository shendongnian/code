    public static void TestSet2()
    {
       var uList = CreateUsers().ToList();
       var jList = CreateJournals(uList.ElementAt(0));
       _db.UserProfiles.Add(uList.ElementAt(0));
       _db.Journals.Add(jList.ElementAt(0));
       _db.Commit();
    }
