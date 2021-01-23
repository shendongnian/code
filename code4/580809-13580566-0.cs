    using System.Reflection;
    //...
    var image = new Bitmap(
        Assembly.GetEntryAssembly().
            GetManifestResourceStream("MyProject.Properties.Resources.MyImage.png"));
