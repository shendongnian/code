    public class EFInitializer<T, TP>: EFInitializerBase, IRepositoryInitializer<T> 
            where T : class
            where TP : ObjectContext, IEntityRepository<T>
        {
            public IEntityRepository<T> Create()
            {
                return this.Model.CreateObjectContext<TP>(new SqlConnection(Utility.ConnectionStrings.ConnDefault));
            }
        }
