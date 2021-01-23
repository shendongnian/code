    using Ninject;
    using Ninject.Extensions.Conventions;
    
    namespace NinjectConventionsDemo
    {
        public interface ITool { }
        public class Tool : ITool { }
    
        internal class Program
        {
            private static void Main()
            {
                IKernel kernel = new StandardKernel();
                kernel.Bind(convention => convention
                                              .FromThisAssembly()
                                              .SelectAllClasses()
                                              .BindAllInterfaces()
                    );
                var tool = kernel.Get<ITool>();
            }
        }
    }
