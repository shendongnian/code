    public static class ConnectionStringFactory
    {
        public static IEnumerable<string> GetConnectionString()
        {
            yield return "connString";
        }
    }
    [Factory(typeof(ConnectionStringFactory), "GetConnectionString")]
    public class CustomerTests
    {
        [Test]
        public void GetCustomerTest(string connectionString)
        {
            Console.WriteLine(connectionString);
        }
        [Test]
        public void GetCustomersTest(string connectionString)
        {
            Console.WriteLine(connectionString);
        }
    }
