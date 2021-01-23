    interface IMapper<T> where T : IModel
    {
        void Create(T model);
    }
    ...
    public class CustomerMapper : IMapper<Customer>
    {
        public void Create(Customer model) {}
    }
