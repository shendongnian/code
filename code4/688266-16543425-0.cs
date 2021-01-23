        public interface IUserProvider
        {
            User CurrentUser { get; }
        }
        
        public class ModelCreator
        {
            public ModelCreator(IUserProvider provider)
            {
                this.provider = provider;
            }
            IUserProvider provider;
            public Invoice Get(){
                User currentUser = provider.CurrentUser;
                // do other
            }
        }
