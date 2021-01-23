    public static T SomeMethod<T>(IEntity<T> entity)
    {
    	T target = entity.GetThis(); //Generic GetThis called
    	return target;
    }
    
    public static object SomeNonGenericMethod(IEntity entity)
    {
    	object target = entity.GetThis(); //Non-generic GetThis called
    	return target;
    }
    Car car = new Car();
    ICar icar = SomeMethod<ICar>(car);
    
    IEntity someEntity = new Car();
    object obj = SomeNonGenericMethod(someEntity);
