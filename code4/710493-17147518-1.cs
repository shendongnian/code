	[Test]
	public class Action_Test
	{
		var factoryMock = MockRepository.GenerateMock<IPropertyClassFactory>();
		var propertyMock = MockRepository.GenerateMock<IPropertyClass>();
		factoryMock.Stub(f => f.CreateInstance()).Returns(propertyMock);
		var service = new ServiceClass(factoryMock);
		service.Action();
		propertyMock.AssertWasCalled(x => x.DoSomething());
	}
