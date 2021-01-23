        public static Assembly HandleAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("System.Data.SQLite"))
            {
                if (_assembliesResolved)
                    return null;
                Assembly returnValue;
                string executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
                executingAssemblyPath = Path.GetDirectoryName(executingAssemblyPath);
                if (Environment.Is64BitProcess)
                    executingAssemblyPath = Path.Combine(executingAssemblyPath, @"lib-sqlite\x64\", "System.Data.SQLite.dll");
                else //32 bit process
                    executingAssemblyPath = Path.Combine(executingAssemblyPath, @"lib-sqlite\x86\", "System.Data.SQLite.dll");
                returnValue = Assembly.LoadFrom(executingAssemblyPath);
                _assembliesResolved = true;
                return returnValue;
            }
            return null;
        }
