    using System.Reflection;
    // ...
    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyApplication.Resources.MyFile.txt")) {
        using (StreamReader reader = new StreamReader(stream)) {
            string contents = reader.ReadToEnd();
            // Do stuff with the text here
        }
    }
