        static void Main(string[] args)
        {
            Mock<Container> returnContainer = new Mock<Container>();
            var CntnrRepository = new Mock<IRepository<Container>>();
            CntnrRepository.Setup<Container>(repo => repo.Find(x => x.Name == "foo")).Returns(returnContainer.Object);
            var found = CntnrRepository.Object.Find(x => x.Name == "foo");
            // Or if you want to pass the mock repository to a method
            var container = GetContainer(CntnrRepository.Object);
        }
        public static Container GetContainer(IRepository<Container> container)
        {
            return container.Find(x => x.Name == "foo");
        }
