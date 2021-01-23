    [Test]
		public void Test()
		{
			// SETUP
			Mock<IRepository> repository = new Mock<IRepository>();
			Service service = new Service(repository.Object);
			repository.Setup(r => r.Get()).Returns(CreateList());
			IEnumerable<int> addedIds = new[]{1,2};
			IEnumerable<int> removedIds = new[]{3,4};
			service.Save(addedIds, removedIds);
			
			repository.Verify(r => r.Create(It.Is<IEnumerable<int>>(l => VerifyList(l))));
		}
		private static bool VerifyList(IEnumerable<int> enumerable)
		{
			return enumerable.Contains(1) && enumerable.Contains(2) && enumerable.Contains(5);
		}
		private IEnumerable<int> CreateList()
		{
			return new[] { 3, 4, 5 };
		}
		public interface IRepository
		{
			IEnumerable<int> Get();
			int Create(IEnumerable<int> id);
		}
		public class Service
		{
			public Service(IRepository repository)
			{
				this.repository = repository;
			}
			private IRepository repository;
			public int Save(IEnumerable<int> addedIds, IEnumerable<int> removedIds)
		{
			var existingIds = repository.Get();
				IEnumerable<int> ids = existingIds.Except(removedIds).Union(addedIds);
				
			return repository.Create(ids);
		}
