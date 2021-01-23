        public static void Init()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.LoadConfiguration();
            _persistenceFactory = _unityContainer.Resolve<IPersistenceFactory>();
            _unitOfWork = _persistenceFactory.GetUnitOfWork();
            _usersRepository = _persistenceFactory.GetUsersRepository();
            _usersRepository.RemoveAll();
            _unitOfWork.Commit();
        }
        public static void InsertTestData()
        {
           User u = new User("johndoe@gmail.com", "John Doe", "johndoe");
 
            _usersRepository.Add(u);
            _unitOfWork.Commit();
        }
