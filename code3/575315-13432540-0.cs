    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using NUnit.Framework;
    
    namespace TestConsole1
    {
      public interface IEntity
      {
        long Id { get; }
      }
    
      public interface IRepository<T> where T : class, IEntity, new()
      {
        void Save(T entity);
        void Delete(long id);
        T Get(long id);
        IEnumerable<T> GetAll();
      }
    
      public interface IUserRepository : IRepository<User>
      {
        User Login(string username, string password);
      }
    
      public class User : IEntity
      {
    
        // Implementation of User
        public long Id
        {
          get { return 42; }
        }
      }
    
      public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity, new()
      {
        // Implementation of IRepository
        public void Save(T entity)
        {
          throw new NotImplementedException();
        }
    
        public void Delete(long id)
        {
          throw new NotImplementedException();
        }
    
        public T Get(long id)
        {
          throw new NotImplementedException();
        }
    
        public IEnumerable<T> GetAll()
        {
          throw new NotImplementedException();
        }
      }
    
      public class UserRepository : BaseRepository<User>, IUserRepository
      {
        // Implementation of IUserRepository
        // Override BaseRepository if required
        public User Login(string username, string password)
        {
          return new User();
        }
      }
    
      class Factory 
      {
        public T CreateRepository<T>() where T : class 
        {
          //TODO: Implement some caching to avoid overhead of repeated reflection
          var abstractType = typeof(T);
          var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
              .SelectMany(s => s.GetTypes())
              .Where(p => p.IsClass && 
                          !p.IsAbstract && 
                          abstractType.IsAssignableFrom(p));
          
          var concreteType = types.FirstOrDefault();
          if (concreteType == null)
            throw new InvalidOperationException(String.Format("No implementation of {0} was found", abstractType));
    
          return Activator.CreateInstance(concreteType) as T;
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          var factory = new Factory();
          var userRepo = factory.CreateRepository<IUserRepository>();
          Console.WriteLine(userRepo.GetType());
          User user = userRepo.Login("name", "pwd");
          Console.WriteLine(user.Id);
          Console.ReadKey();
        }
      }
    }
