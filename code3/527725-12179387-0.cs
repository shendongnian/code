    public static void Save(T pSaveObj)
    {
      using (ISession session = GetSession())
      {
        using (ITransaction trans = session.BeginTransaction())
        {          
          session.SaveOrUpdate(pSaveObj);                                         
          trans.Commit()
        }
      }
    }
