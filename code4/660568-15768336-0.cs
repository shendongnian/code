        AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(basePath, e.Name + ".dll", SearchOption.AllDirectories);
            return files.Length == 1 ? Assembly.LoadFile(files[0]) : null;
        };
