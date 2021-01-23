    public class MyEntityLogic
    {
        ...
        public MyEntity Save(List<MyEntity> entities)
        {
			MyEntity result = null;
			
            using (var uow = new UnitOfWork(MyContext))
			{
				foreach (var entity in entities)
					result = MyRepository.Save(entity);
				uow.Save(); // This will actually make the changes in the DB.
			}
			
			return result;
        }
		
		...
    }
