    namespace MyApp.InterfaceLayer
    {
    	public interface IFormFactory
    	{
    		IForm GetForm();
    	}
    }
    namespace MyApp.CompositionRoot
    {
    	class FormFactory : IFormFactory
    	{
    		Castle.Windsor.IWindsorContainer Container { get; set; }
    
    		public FormFactory(Castle.Windsor.IWindsorContainer container)
    		{
    			Container = container;
    		}
    		public IForm GetForm()
    		{
    			return Container.Resolve<IForm>();
    		}
    	}
    }
