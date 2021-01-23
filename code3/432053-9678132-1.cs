    public class UnitOfWork : IDisposable 
    { 
        private SchoolDBContext context = new SchoolDBContext(); 
        private GenericRepository<Department> departmentRepository; 
     
        public GenericRepository<Department> DepartmentRepository 
        { 
            get 
            { 
     
                if (this.departmentRepository == null) 
                { 
                    this.departmentRepository = new GenericRepository<Department>(context); 
                } 
                return departmentRepository; 
            } 
        }
        
    	public void Save() 
    	{ 
    	    context.SaveChanges(); 
    	}
    	....
     }
 
 
