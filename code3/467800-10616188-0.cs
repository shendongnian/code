    public class EmployeeRepositoryEF: IEmployeeRepository
    {
        public employee[] GetAll()
        {
            //here you will return employees after querying your EF DbContext
        }
    }
    public class EmployeeRepositoryXML: IEmployeeRepository
    {
        public employee[] GetAll()
        {
            //here you will return employees after querying an XML file
        }
    }
    public class EmployeeRepositoryWCF: IEmployeeRepository
    {
        public employee[] GetAll()
        {
            //here you will return employees after querying some remote WCF service
        }
    }
    and so on ... you could have as many implementation as you like
