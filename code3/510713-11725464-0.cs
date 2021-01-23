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
	interface IRepository<T1, T2> where T1:IEntity where T2:IEntity
	{
		T1 GetAll();
		T2 GetAll();
	}
	class PersonRepository : IRepository<Employees,Students>
	{
		Employees GetAll();
		Students GetAll();
	}
