    public partial class Table1
    {
         public static FromID(int id)
         {
             using (var context = new DBDataContext()) {
                return (Table1)(from c in context.table1
                                where c.ID == id
                                select c).FirstOrDefault();
             }
         }
    }
