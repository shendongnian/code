     void somewhereelse()
    {
      string qry = "select Housemcode,Name, HP,Rateperhour ,Resource_H_Code FROM House_Machinery    where Housemcode like '" + sSearch + "'";
      filldetails(qry);
    }
    
    protected void filldetails(string someqry)
    {
      everythingelse();
    }
