    try
       {
          var _assembly = Assembly.GetExecutingAssembly();
          var _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("MyNamespace.MyTextFile.txt"));
    var text = _textStreamReader.ReadToEnd();
    // use the variable text for something...
       }
       catch
       {
          MessageBox.Show("Error accessing resources!");
       }
