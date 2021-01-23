    public interface IRepositoryFactory
        {
            IRepositoryOne GetRepositoryOne();
            IRepositoryTwo GetRepositoryTwo();
        }
    
     public class RepositoryFactory: IRepositoryFactory
        {
    
            public DataAccess.RepositoryInterfaces.IRepositoryOne GetRepositoryOne()
            {
                return new RepositoryOne();
            }
            public DataAccess.RepositoryInterfaces.IRepositoryTwo GetRepositoryTwo()
            {
                return new RepositoryTwo();
            }
    }
