        public static string GetCoreAssemblyPathRoot()
        {
            const string AssemblyName = "MyAssemblyName,";
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var path = (from assembly in loadedAssemblies
                        where assembly.FullName.StartsWith(AssemblyName)
                        select Path.GetDirectoryName(assembly.Location))
                       .FirstOrDefault();
            if (path == null)
            {
                return null;
            }
            //  The last part of the path is "\bin". Remove it, and return the remainder.
            var index = path.IndexOf("\\bin\\");
            return index == -1
                       ? path
                       : path.Substring(0, index);
        }
