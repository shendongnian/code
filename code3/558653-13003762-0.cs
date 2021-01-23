        static void Main(string[] args)
        {
            DumpExports(typeof (string).Assembly);
        }
        public static void DumpExports( Assembly assembly)
        {
            Dictionary<Type, List<MethodInfo>> exports = assembly.GetTypes()
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                                        .Where(method => method.GetCustomAttributes(typeof (DllImportAttribute), false).Length > 0))
                .GroupBy(method => method.DeclaringType)
                .ToDictionary( item => item.Key, item => item.ToList())
                ;
            foreach( var item in exports )
            {
                Console.WriteLine(item.Key.FullName);
                foreach( var method in  item.Value )
                {
                    DllImportAttribute attr = method.GetCustomAttributes(typeof (DllImportAttribute), false)[0] as DllImportAttribute;
                    Console.WriteLine("\tDLL: {0}, Function: {1}", attr.Value, method.Name);
                }
            }
        }
