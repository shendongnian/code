    public class BaseRepository
    {
        public sealed class RepositoryFactory
        {
            public static BaseRepository Create()
            {
                var repo = new BaseRepository();
    
                repo.MethodRequiredByRepositoryFactory();
    
                return repo;
            }
        }
    
        private void MethodRequiredByRepositoryFactory() { }
    }
