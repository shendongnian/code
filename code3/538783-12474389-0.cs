	// Dummy types for test usage only
	public interface ICorrectRepository { }
	public class FakeCorrectRepository : ICorrectRepository { }
    [Test]
    Process_RegistersFakeRepositoryType_ThroughInterfaceTypeName()
	{
		var registry = new Registry();
        var convention = new FakeRepositoriesConvention();
		
		// exercise test
		convention.Process(typeof(FakeCorrectRepository), registry);
		
		// assert it worked
		var container = new Container(c => c.AddRegistry(registry));
		var instance = container.GetInstance<ICorrectRepository>();
		Assert.That(instance, Is.Not.Null);
	}
	
