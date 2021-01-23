    public class ABCTest
    {
        public class TestConnectionManager : IConnectionManager
        {
            public string GetConnection()
            {
                return  @"Data Source=servername\MSSQLSERVER2008;Initial Catalog=DB1;User ID=user1;Password=pswd1";
            }
        }
        public void MethodATest()
        {
            var abc = new ABC(new TestConnectionManager());
        
        }
    }
    public interface IConnectionManager
    {
        string GetConnection();
    }
    public class ConnectionManager : IConnectionManager
    {
        public string GetConnection()
        {
            return SqlConnectionManager.Instance.GetDefaultConnection();
        }
    }
    public class ABC()
    {
        IConnectionManager connectionManager;
        public ABC(IConnectionManager cm)
        {
            connectionManager = cm;
        }
        public void A()
        {
            //create connection from connectionManager.GetConnection()
            using(dwconn)
            {
            //some stuff
            }
        }
    }
