    enum SortDirection {
        Ascending,
        Descending
    }
    
    static  List<Employee> GetMyData(int pageIndex, int pageSize, out int itemCount, string sortField, SortDirection sortDirection )
    {
        //.........
        //.........  
        
        int startIndex = pageIndex * pageSize; //pageIndex is Zero-based
        int endIndex = startIndex + pageSize;
        //Get subset of employees based on paging and sorting parameters
        //Sorting can be based on EmpID or EmpName <-- this is why I can use the ? below
        List<Employee> currentPageEmployees = 
              sortDirection == SortDirection.Ascending ? 
              employees.OrderBy(e=>sortField=="EmpID" ? e.EmpID : e.EmpName)
                       .Where((e,i)=>i>=startIndex&&i<endIndex)
              :
              employees.OrderByDescending(e=>sortField=="EmpID" ? e.EmpID : e.EmpName)
                       .Where((e,i)=>i>=startIndex&&i<endIndex);
        return currentPageEmployees;
    }
