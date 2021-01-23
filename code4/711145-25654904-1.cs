	#region
	using System;
	using Microsoft.Practices.Unity;
	
	#endregion
	
	namespace Demo___Unity
	{
	    internal class Program
	    {
	        private static void Main(string[] args)
	        {
	            using (var container = new UnityContainer())
	            {
	                // Manual method.
	                //container.RegisterType<IEntryPoint, EntryPoint>();
	                //container.RegisterType<IInjected, Injected>();
	
                    // Set up registration by convention.
	                // http://blogs.msdn.com/b/agile/archive/2013/03/12/unity-configuration-registration-by-convention.aspx
	                container.RegisterTypes(
	                    AllClasses.FromAssembliesInBasePath(),
	                    WithMappings.FromMatchingInterface,
	                    WithName.Default,
	                    WithLifetime.ContainerControlled);
	
	                var controller = container.Resolve<IEntryPoint>();
	                controller.Main();
	            }
	        }
	    }
	
	    public interface IEntryPoint
	    {
	        string Name { get; set; }
	        void Main();
	    }
	
	    public class EntryPoint : IEntryPoint
	    {
	        private readonly IInjected Injected;
	
	        public EntryPoint(IInjected injected)
	        {
	            Injected = injected;
	        }
	
	        public void Main()
	        {
	            Console.Write("Hello, world!\n");
	            Injected.SubMain();
	            Injected2.SubMain();
	            Console.Write("[any key to continue]");
	            Console.ReadKey();
	        }
	
	        // Demonstrates property injection.
	        [Dependency]
	        public IInjected Injected2 { get; set; }
	
	        public string Name { get; set; }
	    }
	
	    public interface IInjected
	    {
	        void SubMain();
	    }
	
	    public class Injected : IInjected
	    {
	        public void SubMain()
	        {
	            Console.Write("Hello, sub world!\n");
	        }
	
	        public string Name { get; set; }
	    }
	}
