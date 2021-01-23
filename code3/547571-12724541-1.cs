    public enum YourEnum
    {
    	Option1
    }
    
    public IYourTypedFactory
    {
    	IYourTyped GetById(YourEnum enumValue)
    }
    
    
    container.AddFacility<TypedFactoryFacility>();
    container.Register
    (		
    	Component.For<ByIdTypedFactoryComponentSelector>(),
    
    	Component.For<IYourTyped>().ImplementedBy<FooYourTyped>().Named(YourEnum.Option1.ToString()),
    
    	Component.For<IYourTypedFactory>()
    	.AsFactory(x => x.SelectedWith<ByIdTypedFactoryComponentSelector>())
    	.LifeStyle.Singleton,
    	
    	...
