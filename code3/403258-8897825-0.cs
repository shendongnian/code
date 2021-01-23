    public static Department FindDepartment(this Employee emp)
    {
        if(emp.ID > 500)
        {
             return new Department("Department for Over 500");
        }else{
             return new Department("Department for 500 and under");
        }
    }
