    try
    {
       _assembly = Assembly.GetExecutingAssembly();
       _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("MYHTMLFile.html"));
    }
    catch
    {
       MessageBox.Show("Error accessing resources!");
    }
