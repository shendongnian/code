    public class MyService
    {
        readonly Func<IUnitOfWork> _unitOfWorkFactory;
        
        public MyService(Func<IUnitOfWork> unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        
        public void DoServiceStuff()
        {
            using(var uow = _unitOfWorkFactory())
            {
                var newUser = new User() { Username = "My User" };
                
                var userRepo = uow.GetRepository<User>();
                userRepo.Add(newUser);
                
                uow.Save();
            }
        }
    }
