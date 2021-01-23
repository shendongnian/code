    public class Employee : IDisposable
    {
    
        SoapSample company = new SoapSample();
    
        public Employee()
        {
            company.UserCredentials.UserName = "";
            company.UserCredentials.Password = "";
        }
        public void Dispose()
        {
             //TODO:put your cleanup code here
        }
    
    }
