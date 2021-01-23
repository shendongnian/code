    if (ApplicationDeployment.IsNetworkDeployed)
    {
        var deployment = ApplicationDeployment.CurrentDeployment;
        if (deployment.IsFileGroupDownloaded("GROUPA"))
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileToDelete = Path.Combine(path, "somefile.txt");
            File.Delete(fileToDelete);
        }
    }
