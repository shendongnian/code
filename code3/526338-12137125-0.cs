    public class ExampleKernel : NinjectModule
    {
    	public override void Load()
    	{
    		Bind<IRandomProvider>()
    			.To<RandomProvider>();
    			
    		Bind<Die>()
    			.ToSelf()
    			.WithConstructorArgument("numSides", 6);
                               //  default value for numSides
    	}
    }
