    public class SomeActivity
    {
        public SomeActivity(IRepository<Department> departments) { }
    }
    public class MainActivity
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainActivity(IUnitOfWork unitOfWork, SomeActivity activity) 
        {
            _unitOfWork = unitOfWork;
        }
        public void test()
        {
            _unitOfWork.Commit();
        }
    }
