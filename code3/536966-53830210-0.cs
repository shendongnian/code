    using System.Linq.Dynamic;
    public IEnumerable MyTable MySelect(string colName, string param)
    {
      using (MyEntities db = new MyEntities ())
      {
         var query = db.MyTable.Where($"{colName} LIKE %{param}%");
         return query;
      }
    }
