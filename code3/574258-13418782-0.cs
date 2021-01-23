      var CustomerGeneric = GenericFluentFactory<Customer, WebSession>
                            .Init(new Customer(), new WebSession())
                            .Create();
    
    public static class GenericFluentFactory<T, U>
    {
        public static IGenericFactory<T, U> Init(T entity, U session)
        {
            return new GenericFactory<T, U>(entity, session);
        }        
    }
    public class GenericFactory<T, U> : IGenericFactory<T, U>
    {
        T entity;
        U session;
        public GenericFactory(T entity, U session)
        {
            this.entity = entity;
            this.session = session;
        }
        public T Create()
        {
            return this.entity;
        }
    }
