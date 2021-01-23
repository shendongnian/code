    interface IUnload<out T> where T : Animal
    {
    	IEnumerable<T> GetAll();
    }
    
    class UnloadTeam<T> : IUnload<T> where T : Animal
    {
    	public IEnumerable<T> GetAll()
    	{
    		return Enumerable.Empty<T>();
    	}
    }
    IUnload<Animal> unloadTeam = new UnloadTeam<Bird>();//Covariance, since Bird is more specific then Animal
    var animals = unloadTeam.GetAll();
