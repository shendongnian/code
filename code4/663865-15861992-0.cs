    namespace AttributePlayground
    {
        class Program
        {
            static void Main(string[] args)
            {
                var moduleDict = makeModuleDict();
            }
    
            public static Dictionary<string, List<string>> makeModuleDict()
            {
                var attribs = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(
                        x => x.GetTypes()
                            .SelectMany(
                                y => y.GetCustomAttributes(typeof(JIMSExport), false)
                            )
                    )
                    .OfType<JIMSExport>();
    
                return attribs
                    .GroupBy(x => x.Module)
                    .ToDictionary(
                        x => x.Key,
                        x => new List<String>(
                            x.Select(y => y.ContractName)
                            )
                        );
    
            }
        
        }
    
        [JIMSExport("Module1", "Contract1")]
        public class TestClass1
        {
    
        }
    
        [JIMSExport("Module1", "Contract2")]
        public class TestClass2
        {
    
        }
    
        [JIMSExport("Module2", "Contract3")]
        public class TestClass3
        {
    
        }
    
        [JIMSExport("Module2", "Contract4")]
        public class TestClass4
        {
    
        }
    
        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
        sealed class JIMSExport : Attribute
        {
            public readonly string ContractName;
            public readonly string Module;
            public JIMSExport(string Module,string ContractName)
            {
                this.Module = Module;
                this.ContractName = ContractName;
            }
    
        }
    }
