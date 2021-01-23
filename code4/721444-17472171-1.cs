    public class RepositoryFactory<TPoco> where TPoco : BaseObjectConstraintHere {
        public IRepositoryBase<TPoco> GetRepository(DbContext context) {
           // get the Pocotype for generic repository instantiation
            var pocoTypes = new[] {typeof (TPoco)};  // but you can also extend to  <T,U>
            Type repBaseType = GetRepositoryType(typeof(TPoco)); // get the best matching Class type
            // now make one of those please..
            IRepositoryBase<TPoco> repository = InstantiateRepository(context, repBaseType, pocoTypes);
         
           return repository;
        }
        private Type GetRepositoryType(Type T) { 
            if (ConditionX) {
                return typeof(RepositoryX<>);
            }
            return typeof (RepositoryY<>);
        }  // note you can return Repository<,>   if the type requires 2 generic params
        // Now instantiate Class Type with the Generic type passing in a constructor param  
        private IRepositoryBase<TPoco> InstantiateRepository(BosBaseDbContext context, Type repType, params Type[] pocoTypes) {
             
            Type repGenericType = repType.MakeGenericType(pocoTypes);
            object repInstance = Activator.CreateInstance(repGenericType, context);
            return (IRepositoryBase<TPoco>)repInstance;
        }
    }
