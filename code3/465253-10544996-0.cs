 	class RepositoryFactory
	{
		IRepository<T>  Get(rowType)
		{
		    IRepository<T> repository = default(IRepository<T>);
		    switch (rowType)
			{
			case Carton:
				repository = new CartonRepository();
				break;
			case Pack:
				repository = new PackRepository();
				break;
			}
			
			return repository;
		}
	}
