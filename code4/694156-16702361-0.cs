    class Department
    {
        public string Name {get;set;}
        public List<User> Users {get;set;}
    }
    List<Department> departments;
    foo()
    {
       foreach(department in departments)
       {
           // emit optgroup
           foreach(user in department.Users)
           {
               // emit option
           }
           // emit /optgroup
       }
    }
