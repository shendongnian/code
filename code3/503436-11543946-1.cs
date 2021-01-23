    [System.ComponentModel.DataObject]
    public class MyObject
    {
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        public IEnumerable<employee> FindPaging(int startIndex, int pageSize, string sortColumn)
        {
            // place here your code to access your database and use the parameters to paginate your results in the server
        }
    
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        public int FindPagingCount(int startIndex, int pageSize, string sortColumn)
        {
            var c = new DataClassesDataContext();
    
            return c.employees.Count();
        }
    }
