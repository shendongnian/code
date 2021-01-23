    public class Department { }
    public class Student { }
    public class DepartmentRepository : GenericRepository<Department> 
    {
        public DepartmentRepository(IUnitOfWork unitOfWork): base(unitOfWork) { }
    }
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
