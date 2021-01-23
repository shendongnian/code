    bool ret= new bool();
    if ((!String.IsNullOrEmpty(foo1)) && (!String.IsNullOrEmpty(foo2)))
    {
     using (NHibernate.ISession nhSession = ConexionDB.SessionFactory.OpenSession())
     {
     try
     {
      User u = new User();
      //set your User
      nhSession.Transaction.Begin();
      nhSession.Save(u);
      nhSession.Transaction.Commit();
      nhSession.Close();
        
      ret = true;
     }
     catch (Exception ex)
     {
     ret = false;
     }
    }
    return ret;
