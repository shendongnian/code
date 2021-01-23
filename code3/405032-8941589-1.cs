    class EmployeeList
    {
       List<Employee> list = new List<Employee>();
       public void addEmployee(Employee a)
       {
           this.list.Add(a);
       }
        public Employee GetEmployee(int Index)
        {
            var e = list[Index]; 
            return e;  //No cast needed 
        }
    }
