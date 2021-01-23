    public static Table1 TableFromId(int Id)
    {
         using (DBDataContext item = new DBDataContext())
            {
                return  (from c in item.table1
                         where c.ID == id
                         select c).FirstOrDefault() as Table1;
            }
    }
