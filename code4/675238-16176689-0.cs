    [Serializable]
    public partial class Employee
    {
        public int EmployeeKey { get; set; }                   
        public string LastName { get; set; }                   
        public string FirstName { get; set; }   
        public DateTime HireDate  { get; set; }  
    }
    
    [Serializable]
    public class EmployeeCollection : List<Employee>
    {
    }   
    
    internal static class EmployeeSearchResultsLayouts
    {
        public static readonly int EMPLOYEE_KEY = 0;
        public static readonly int LAST_NAME = 1;
        public static readonly int FIRST_NAME = 2;
        public static readonly int HIRE_DATE = 3;
    }
    
    
        public EmployeeCollection SerializeEmployeeSearchForCollection(IDataReader dataReader)
        {
            Employee item = new Employee();
            EmployeeCollection returnCollection = new EmployeeCollection();
            try
            {
    
                int fc = dataReader.FieldCount;//just an FYI value
    
                int counter = 0;//just an fyi of the number of rows
    
                while (dataReader.Read())
                {
    
                    if (!(dataReader.IsDBNull(EmployeeSearchResultsLayouts.EMPLOYEE_KEY)))
                    {
                        item = new Employee() { EmployeeKey = dataReader.GetInt32(EmployeeSearchResultsLayouts.EMPLOYEE_KEY) };
    
                        if (!(dataReader.IsDBNull(EmployeeSearchResultsLayouts.LAST_NAME)))
                        {
                            item.LastName = dataReader.GetString(EmployeeSearchResultsLayouts.LAST_NAME);
                        }
    
                        if (!(dataReader.IsDBNull(EmployeeSearchResultsLayouts.FIRST_NAME)))
                        {
                            item.FirstName = dataReader.GetString(EmployeeSearchResultsLayouts.FIRST_NAME);
                        }
    
                        if (!(dataReader.IsDBNull(EmployeeSearchResultsLayouts.HIRE_DATE)))
                        {
                            item.HireDate = dataReader.GetDateTime(EmployeeSearchResultsLayouts.HIRE_DATE);
                        }
    
    
                        returnCollection.Add(item);
                    }
    
                    counter++;
                }
    
                return returnCollection;
    
            }
            //no catch here... see  http://blogs.msdn.com/brada/archive/2004/12/03/274718.aspx
            finally
            {
                if (!((dataReader == null)))
                {
                    try
                    {
                        dataReader.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }
