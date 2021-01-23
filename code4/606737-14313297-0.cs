     public class YourContext : DbContext
     {
        protected ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }
    
        public YourContext(string connectionString):base(connectionString)
        {
            ObjectContext.ObjectMaterialized += ObjectMaterialized;
        }
    
        void ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            dynamic entity = e.Entity;
            entity.Initialize();
        }
     }
