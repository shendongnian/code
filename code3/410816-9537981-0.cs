    public abstract class Base<Entity, ViewModel>  	
		where Entity : EntityObject 		
		where ViewModel : BaseViewModel		
        {
            // you will call this method from your operations class using base
            public SomeViewModel GetData()
            {
                public Entity entityObject = db.Entity.SingleOrDefault();
                public ViewModel yourViewModelName = base.Map(entityObject);
          
                return yourViewModelName;
            }
            ....
            // this will be defined only once for each mapping direction
            // ie. there will be multiple of these.
            public static Entity Map(ViewModel typeViewModel)
            {
                try
	            {
                    Mapper.CreateMap<ViewModel, Entity>();
                    Entity t = Mapper.Map<ViewModel, Entity>(typeViewModel);
                    return t;
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
    
    // this will be your class for database operations on specific Entity
    // that inherits generic base, with its AutoMapping setup.
    public class DataBaseOperationsClass : Base<SomeEntity, SomeViewModel>
    {
        public SomeViewModel Get()
        { 
            return base.GetData();
        }
    }
