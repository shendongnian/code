    abstract class BaseEntity
    {
    }
    
    abstract class BaseEntityWithID<TEntity> : IPrimaryKey<Guid, TEntity>
    {
    	public ID<Guid, TEntity> ID
    	{
    		get;
    		set;
    	}
    }
    
    class TestOne : BaseEntityWithID<TestOne>
    {
    	public string TestString { get; set; }
    }
    
    class TestTwo : BaseEntityWithID<TestTwo>
    {
    	public string TestString { get; set; }
    }
    
    interface IPrimaryKey<T, TEntity>
    {
    	ID<T, TEntity> ID { get; set; }
    }
    
    struct ID<T, TEntity> : IEquatable<ID<T, TEntity>>
    {
    	readonly T _id;
    
    	public ID(T id)
    	{
    		_id = id;
    	}
    
    	public T Value { get { return _id; } }
    
    	public bool Equals(ID<T, TEntity> other)
    	{
    		if (_id == null || other._id == null)
    			return object.Equals(_id, other._id);
    
    		return _id.Equals(other._id);
    	}
    
    	public static implicit operator T(ID<T, TEntity> id)
    	{
    		return id.Value;
    	}
    
    	public static implicit operator ID<T, TEntity>(T id)
    	{
    		return new ID<T, TEntity>(id);
    	}
    	//I believe this class also needs to override GetHashCode() and Equals()
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var testOneStore = new Dictionary<ID<Guid, TestOne>, TestOne>();
    		var testTwoStore = new Dictionary<ID<Guid, TestTwo>, TestTwo>();
    
    		Func<TestOne, TestOne> addTestOne = (entity) =>
    		{
    			if (entity.ID == Guid.Empty)
    			{
    				entity.ID = Guid.NewGuid();
    			}
    
    			testOneStore.Add(entity.ID, entity);
    
    			return entity;
    		};
    
    		Func<TestTwo, TestTwo> addTestTwo = (entity) =>
    		{
    			if (entity.ID == Guid.Empty)
    			{
    				entity.ID = Guid.NewGuid();
    			}
    
    			testTwoStore.Add(entity.ID, entity);
    
    			return entity;
    		};
    
    		var id1 = addTestOne(new TestOne { TestString = "hi" }).ID;
    		var id2 = addTestTwo(new TestTwo { TestString = "hello" }).ID;
    
    		Console.WriteLine(testOneStore[id1].TestString); //this line works
    		Console.WriteLine(testOneStore[id2].TestString); //this line gives a compile-time error
    
    		Console.ReadKey(true);
    	}
    }
