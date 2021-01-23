    private EntityRef<Department> _department;
    [Association(Name = "FK_Person_PersonDepartment", IsForeignKey = true,
       Storage = "_department", ThisKey = "personDepartmentID", OtherKey = "departmentID")]
    public Department Department
    {
      get { return _department.Entity; }
      set { _department.Entity = value; }
    }
