    public static class SomeTableRepository
    {
       public static class GetSomeTableRow(this DatabaseEntities db, int id)
       {
            return db.SomeTable.SingleOrDefault(r => r.Id == 5);
       }
    }
    ...
 
    database.GetSomeTableRow(id);
