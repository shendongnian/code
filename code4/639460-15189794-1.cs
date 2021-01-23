    var templateInstance = new MyTemplate();
    templateInstance.Session = new Dictionary<string, object>();
    templateInstance.Session.Add("MyObject", new MyType());
    var generatedCode = templateInstance.TransformText();
    System.IO.File.WriteAllText("outputfile.java", generatedCode);
