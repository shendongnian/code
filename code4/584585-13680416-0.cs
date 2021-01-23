    [TestFixture]
        public class TestPointer
        {
            private IRepository<User> Repository;
            private UserService Service;
            private Mock<IRepository<User>> MockUserRepository = new Mock<IRepository<User>>();
    
            [Test]
            public void GetItemsByUserName_UserName_ListOfItems()
            {
                //Arrange
                var unitOfWork = new UnitOfWork();
                Service = new UserService(unitOfWork,  MockUserRepository.Object);
                var Tags = new List<Tag>() { new Tag { Name = "TestTag1" }, new Tag { Name = "TestTag2" }, new Tag { Name = "TestTag3" } };
                var user = new User() {Id = 1};
                MockUserRepository.Setup(x => x.Find(1)).Returns(user);
                MockUserRepository.Setup(x => x.Update(user)).Returns(user);
    
                //Act
                var result = Service.AddTags(1, Tags);
    
    
                //Assert
                Assert.AreEqual(result.Tags.Count(),3);
            }
        }
    
        public class UserService
        {
            private IRepository<User> _repository;
            private UnitOfWork _unitOfWork;
    
            public UserService(UnitOfWork unitOfWork, IRepository<User> repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }
    
            public User AddTags(int userId, List<Tag> Tags)
            {
                var user = GetUserById(userId);
                Tags.ForEach(tag => user.Tags.Add(tag));
                return _repository.Update(user);
            }
    
            private User GetUserById(int userId)
            {
                return _repository.Find(userId);
            }
        }
    
        public class UnitOfWork
        {
        
        }
    
        public interface IRepository<T> where T:class
        {
            T Find(int id);
            void Add(T item);
            void Remove(T item);
            T Update(T item);
        }
    
        public class User
        {
            private List<Tag> tags = new List<Tag>();
    
            public int Id { get; set; }
            public List<Tag> Tags
            {
                get { return tags; }
                set { tags = value; }
            }
        }
    
        public class Tag
        {
            public string Name { get; set; }
        }
