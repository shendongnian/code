    public abstract class DeleterTests<TRepository> where TRepository : IRepository
    {
        [TestMethod]
        public void TestDelete()
        {
            var mockRepo = new Mock<TRepository>();
            var container = new UnityContainer();
            container.RegisterInstance<TRepository>(mockRepo.Object);
    
            var deleter = this.CreateDeleter(container);
    
            deleter.Delete("id");
            mockRepo.Verify(r => r.Delete("id"));
        }
    
        protected abstract IDeleter CreateDeleter(IUnityContainer container);
    }
