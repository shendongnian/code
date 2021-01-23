	// base interface for entity types
	interface IEntity 
	{
	}
	class Employees : IEntity
	{
	}
	class Students : IEntity
	{
	}
	interface IRepository 
	{
		RegisterEntities(IEnumerable<IEntity> entities);
		
		IEnumerable<IEntity> GetAll();
	}
	class PersonRepository : IRepository
	{
		IEnumerable<IEntity> GetAll() 
		{
		   // Todo
		}
        }
