    [DataObjectMethod(DataObjectMethodType.Delete)]
    
        public void DeleteEmployee(Employee z)
        {
            using (var ctx = new MyEntity())
            {
                var x = (from y in ctx.Employees
                         where  y.EmployeeId == z.EmployeeId
                         select y).FirstOrDefault();
                 if(x!=null)
                 {
                 ctx.DeleteObject(x);
                 ctx.SaveChanges();
                 }
            }
         }
