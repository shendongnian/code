    public interface IPersonRepository
    {
        void Add(Person person);
        void Remove(Person person);
    
        void GetById(int personId);
    }
