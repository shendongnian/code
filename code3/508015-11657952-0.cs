    public static void GetEmployeeRecord(corpEmployee.Employee QueryData)
    {
        //QueryData is a newly created Employee here, and is NOT the same one that was passed in.
        try
        {
            List<corpEmployee.Employee> empRecord = new List<corpEmployee.Employee>();
            corpCustomerDAL.GetEmployeeData(empRecord, QueryData);//
            //QueryData now contains the data you want your original object to contain
        }
        catch (Exception ex)
        {
        LogAppError(ex.ToString());
        }
    }  //when this function terminates, QueryData ceases to exist.
