    var rootPath = Path.GetDirectoryName(this.Host.TemplateFile);
    var imagesPath = Path.Combine(rootPath, "Images");
    var resourcesPath = Path.Combine(rootPath, "Resources");
    
    var pictures = Directory.GetFiles(imagesPath, "*.png", SearchOption.AllDirectories);
    EnvDTE.DTE dte = (EnvDTE.DTE)((IServiceProvider)this.Host)
                       .GetService(typeof(EnvDTE.DTE));
    EnvDTE.Projects projects = dte.Solution.Projects;
    EnvDTE.Project iconProject = projects.Cast<EnvDTE.Project>().Where(p => p.Name == "Icons").Single();
    EnvDTE.ProjectItem resourcesFolder = iconProject.ProjectItems.Cast<EnvDTE.ProjectItem>().Where(item => item.Name == "Resources").Single();
    
    // Delete all existing resource files to avoid any conflicts.
    foreach (var item in resourcesFolder.ProjectItems.Cast<EnvDTE.ProjectItem>())
    {
        item.Delete();
    }
    
    // Create the needed .resx file fore each picture.
    foreach (var picture in pictures)
    {
        var resourceFilename =  Path.GetFileNameWithoutExtension(picture) + ".resx";
        var resourceFilePath = Path.Combine(resourcesPath, resourceFilename);
        using (var writer = new ResXResourceWriter(resourceFilePath))
        {
            foreach (var picture in picturesByBitmapCollection)
            {
                writer.AddResource(picture.PictureName, new ResXFileRef(picture, typeof(Bitmap).AssemblyQualifiedName));
            }
        }
    }
    
    // Add the .resx file to the project and set the CustomTool property.
    foreach (var resourceFile in Directory.GetFiles(resourcesPath, "*.resx"))
    {
        var createdItem = resourcesFolder.Collection.AddFromFile(resourceFile);
        var allProperties = createdItem.Properties.Cast<EnvDTE.Property>().ToList();
        createdItem.Properties.Item("CustomTool").Value = "ResXFileCodeGenerator";
    }
