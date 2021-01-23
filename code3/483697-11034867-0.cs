     public interface IRepository<T> where T : EntityObject
     {
        RepositoryInstructionResult Add(T item);
        RepositoryInstructionResult Update(T item);
        RepositoryInstructionResult Delete(T item);
     }
     public class Repository<T> : IRepository<T> where T : EntityObject
     {
        virtual RepositoryInstructionResult Add(T item)
        { //implementation}
        virtual RepositoryInstructionResult Update(T item);
        { //implementation}
        virtual RepositoryInstructionResult Delete(T item);
        { //implementation}
      }
