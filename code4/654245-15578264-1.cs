    public class Repository<D,E> : IGenericRepositoryOne<D>, IGenericRepositoryTwo<D,E> 
        where D : Entity
        where E : Entity
    {
        void Save(D dto) {}
        void Save(List<D> entityList) {}
        D Load(Guid entityId)
        {
              // Implement...
        }
    }
