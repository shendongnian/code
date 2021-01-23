    public void DeleteEmployeeId(Employee z)
    {
        using (var ctx = new MyEntityContext())  
        {  
            var x = new Employee{ EmployeeId = z.EmployeeId };
            ctx.Entry(x).State = EntityState.Deleted;  
            ctx.SaveChanges();  
        }
    }
