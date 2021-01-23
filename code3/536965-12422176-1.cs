    public IEnumerable MySelect(string colName, string param)
    {
      using (MyEntities db = new MyEntities ())
      {
         var query = from res in db.MyTable.AsEnumerable()
         where res.Field<string>(colName).Contains(param)
         select res;
         return query;
      }
    }
