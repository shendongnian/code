        static void Main(string[] args)
        {
            foreach (var key in GetPrimaryKeys(@"root\cimv2\win32_devicebus"))
            {
                Console.WriteLine(key);
            }
        }
        static List<string> GetPrimaryKeys(string classPath, string computer = ".")
        {
            var keys = new List<string>();
            var scope = new ManagementScope(string.Format(@"\\{0}\{1}", computer, System.IO.Path.GetDirectoryName(classPath)));
            var path = new ManagementPath(System.IO.Path.GetFileName(classPath));
            var options = new ObjectGetOptions(null, TimeSpan.MaxValue, true);
            using (var mc = new ManagementClass(scope, path, options))
            {
                foreach (var property in mc.Properties)
                {
                    foreach (var qualifier in property.Qualifiers)
                    {
                        if (qualifier.Name.Equals("key") && ((System.Boolean)qualifier.Value))
                        {
                            keys.Add(property.Name);
                            break;
                        }
                    }
                }
            }
            return keys;
        }
