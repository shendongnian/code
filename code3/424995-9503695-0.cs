private interface IDeleteOrganization
{
	 
}
private class DeleteOrganization : IDeleteOrganization
{
	
}
[TestMethod]
public void CanResolveConcreteType()
{
	var builder = new ContainerBuilder();
	builder.RegisterType<DeleteOrganization>()
		.As<IDeleteOrganization>();
	using(var container = builder.Build())
	{
		var registration = container.ComponentRegistry
			.RegistrationsFor(new TypedService(typeof (IDeleteOrganization)))
			.SingleOrDefault();
		if (registration != null)
		{
			var activator = registration.Activator as ReflectionActivator;
			if (activator != null)
			{
				//we can get the type
				var type = activator.LimitType;
				Assert.AreEqual(type, typeof (DeleteOrganization));
			}
		}
	}
}
