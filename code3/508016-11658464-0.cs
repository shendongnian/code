    public static corpEmployee.Employee GetEmployeeRecord(corpEmployee queryData)
    {
        List<corpEmployee.Employee> empRecord = new List<corpEmployee.Employee>();
        corpCustomerDAL.GetEmployeeData(empRecord, QueryData);
        return empRecord.Count == 0 ? null : empRecord[0];  //or empRecord.FirstOrDefault()
    }
