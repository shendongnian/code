            // This code I was already using:
            String binPath = String.Empty;
            if (!String.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath))
            {
                String[] paths = AppDomain.CurrentDomain.RelativeSearchPath.Split(';');
                for (var i = 0; i < paths.Length; i++)
                {
                    paths[i].Remove(0, AppDomain.CurrentDomain.BaseDirectory.Length);
                }
                binPath = String.Join(";", paths);
            }
            Factory.operatingDomain = AppDomain.CreateDomain("my_remote_domain", null,
                new AppDomainSetup
                {
                    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                    // Sometimes, like in a web app, your bin folder is not the same
                    // as the base dir.
                    PrivateBinPath = binPath
                });
            // The new code that solved my problem begins here:
            if (binPath != String.Empty)
            {
                Factory.operatingDomain.SetData("assemblyLocation", Assembly.GetExecutingAssembly().Location);
                Factory.operatingDomain.DoCallBack(() =>
                {
                    String location = AppDomain.CurrentDomain.GetData("assemblyLocation").ToString();
                    String filename = System.IO.Path.GetFileName(location);
                    List<String> paths = AppDomain.CurrentDomain.RelativeSearchPath.Split(';').ToList();
                    foreach (String path in paths.ToArray())
                    {
                        paths.Remove(path);
                        paths.AddRange(System.IO.Directory.GetFiles(path, filename));
                    }
                    Assembly.LoadFrom(paths[0]);
                    AppDomain.CurrentDomain.SetData("assemblyLocation", paths[0]);
                });
                Factory.realAssemblyLocation = Factory.operatingDomain.GetData("assemblyLocation").ToString();
            }
            else
            {
                Factory.operatingDomain.Load(Assembly.GetExecutingAssembly().FullName);
            }
