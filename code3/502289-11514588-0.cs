    public class MyContext : DbContext
    {
        private bool isReadOnly;
        public MyContext(string conn, bool isReadOnly)
        :base(conn)
        {
             this.isReadOnly = isReadOnly;
        }
    
        public override int SaveChanges()
        {
             if (isReadOnly)
             {
                  return 0; //or throw exception
             }
    
             return base.SaveChanges();
        }
    }
