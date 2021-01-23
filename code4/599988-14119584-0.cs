         ProjectCollection pc = new ProjectCollection();
         Dictionary<string, string> GlobalProperty = new Dictionary<string, string>();
         //GlobalProperty.Add("Configuration", "Debug");
         //GlobalProperty.Add("Platform", "x86");
         //GlobalProperty.Add("OutputPath", "c:\\src");
         //GlobalProperty.Add("TargetFrameworkVersion", "4.0");
         
         BuildRequestData buidlRequest = new BuildRequestData("projectfile.csproj", GlobalProperty, null, new string[] { "Build" }, null);
         BuildResult buildResult = BuildManager.DefaultBuildManager.Build(new BuildParameters(pc), buidlRequest);
         //if (buildResult["Build"].ResultCode == TargetResultCode.Success)
         //{
         //   Console.WriteLine("Build Success");
         //}
         //else
         //{
         //   Console.WriteLine("Build Fail");
         //}
