    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Threading;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<double>[] Reg = new List<double>[2]; for (int i = 0; i < Reg.Length; i++) { Reg[i] = new List<double>(); }
                for (int i = 0; i < 100; i++)
                { Reg[1].Add(1.0); }            //Dummy data
                var obj = ClassFactory.CreateStep("AmplifySignal");
                object[] Args = obj.DeserializeProperties(" ");
                Args[0] = Reg;
                dynamic result = obj.Run(Args);
                if (result != null)
                { Thread.Sleep(0); }    //breakpoint
                Console.ReadKey();
            }
        }
        internal static class ClassFactory
        {
            private static readonly IDictionary<String, Type> _recipe_instructions;
            static ClassFactory() { _recipe_instructions = MapIRecipe(); }
            private static IDictionary<string, Type> MapIRecipe()
            {
                // Get the assembly that contains this code
                Assembly asm = Assembly.GetExecutingAssembly();
                // Get a list of all the types in the assembly
                Type[] allTypes = asm.GetTypes();
                var d = new Dictionary<string, Type>();
                foreach (var type in allTypes)
                {
                    if (type.IsClass && !type.IsAbstract && type.GetInterface(typeof(IFactory).ToString()) != null)
                    {
                        // Create a temporary instance of that class...
                        object inst = asm.CreateInstance(type.FullName, true, BindingFlags.CreateInstance, null, null, null, null);
                        if (inst != null)
                        {
                            // And generate the product classes key
                            IFactory mapKey = (IFactory)inst;
                            object key = mapKey.GetFactoryKey();
                            inst = null;
                            //Add the results to a Dictionary with the Name as a key and the Type as the value
                            d.Add((string)key, type);
                        }
                    }
                }
                return d;
            }
            internal static IFactory CreateStep(String key)
            {
                Type type;
                if (_recipe_instructions.TryGetValue(key, out type))
                { return (IFactory)Activator.CreateInstance(type); }
                throw new ArgumentException(String.Format("Unable to locate key: {0}", key));
            }
        }
        public interface IFactory
        {
            string GetFactoryKey();
            string SerializeProperties();
            object[] DeserializeProperties(string args);
            dynamic Run(params object[] args);
        }
        public class AmplifySignal : IFactory
        {
            public string GetFactoryKey()
            { return MethodBase.GetCurrentMethod().DeclaringType.Name; }
            public object[] DeserializeProperties(string args)
            { return new object[] { null, (int)1, (double)2.1 }; }
            public string SerializeProperties()
            { return " 1 | 2.1 "; }
            public dynamic Run(params object[] args)
            {
                // Build Inputs
                List<double>[] registers = (List<double>[])args[0];
                List<double> waveform = (List<double>)registers[(int)args[1]];
                double factor = (double)args[2];
                // Do Work
                double[] Result = waveform.ToArray();      //Localize and Deep Copy
                for (int i = 0; i < Result.Length; i++)
                { Result[i] *= factor; }
                List<double> result = Result.ToList();    //breakpoint
                // Write Result
                return result;
            }
        }
    }
