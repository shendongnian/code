        var currentDomain = AppDomain.CurrentDomain;
            var location = Assembly.GetExecutingAssembly().Location;
            var assemblyDir = Path.GetDirectoryName(location);
            if (assemblyDir != null && (File.Exists(Path.Combine(assemblyDir, "(Assembly name).proxy.dll"))
                                        || !File.Exists(Path.Combine(assemblyDir, "(Assembly name).x86.dll"))
                                        || !File.Exists(Path.Combine(assemblyDir, "(Assembly name).x64.dll"))))
            {
                throw new InvalidOperationException("Found (Assembly name).proxy.dll which cannot exist. "
                    + "Must instead have (Assembly name).x86.dll and (Assembly name).x64.dll. Check your build settings.");
            }
            currentDomain.AssemblyResolve += (sender, arg) =>
            {
                if (arg.Name.StartsWith("(Assembly name),", StringComparison.OrdinalIgnoreCase))
                {
                    string fileName = Path.Combine(assemblyDir,
                        string.Format("(Assembly).{0}.dll", (IntPtr.Size == 4) ? "x86" : "x64"));
                    return Assembly.LoadFile(fileName);
                }
                return null;
            };
