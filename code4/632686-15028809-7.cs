        private void TestCase4_OnClick(object sender, RoutedEventArgs e)
        {
            var globalProperties = new Dictionary<string, string>();
            var buildRequest = new BuildRequestData(@"C:\Users\jbu\wpftest\wpftest.csproj", globalProperties, null, new string[] { "Build" }, null);
            var pc = new ProjectCollection();
            var result = BuildManager.DefaultBuildManager.Build(new BuildParameters(pc), buildRequest);
            Assembly assembly = Assembly.LoadFrom(@"C:\Users\jbu\wpftest\bin\Debug\wpftest.dll");
            var instance = assembly.CreateInstance("wpftest.MainWindow") as Window;
            if (instance != null)
            {
                instance.Show();
            }
        } 
