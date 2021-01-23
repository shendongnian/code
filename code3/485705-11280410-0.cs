    //using System.ComponentModel.Composition;
    //using System.ComponentModel.Composition.Hosting;
    //using MefContrib.Hosting.Interception;
    //using MefContrib.Hosting.Interception.Configuration;
    public class CommandAttributeProcessor : IExportedValueInterceptor
    {
        public object Intercept(object value)
        {
            foreach (MethodInfo methodInfo in value.GetType().GetMethods())
            {
                foreach (CommandAttribute attr in methodInfo.GetCustomAttributes(typeof(CommandAttribute), true))
                {
                    // do something with command attribute
                }
            }
            return value;
        }
    }
