    public interface IConnectionProvider {
        string ConnectionString { get; }
    }
    public interface IAccountProvider {
       Account GetAccountById(int accountID);
    }
    
    internal class AccountProvider : IAccountProvider {
        private IConnectionProvider _connectionProvider;
        public AccountProvider(IConnectionProvider connectionProvider) {
            if (connectionProvider == null) {
              throw new ArgumentNullException("connectionProvider");
            }
            _connectionProvider = connectionProvider;
        }
       public Account GetAccountById(int accountID) {
           Account result;
           using(var conn = new SqlConnection(connectionProvider)) {
             // retrieve result here
           }
           return result;
       }
    }
    
    public static class Bootstrapper {
        public static void Init() {
            ServiceLocator.AddSingleton<IAccountProvider, AccountProvider>();
        }
    }
