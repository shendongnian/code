    Type type = typeof(TestClass);
    Assembly assembly = type.Assembly;
    XmlReflectionImporter importer = new XmlReflectionImporter();
    XmlTypeMapping mapping = importer.ImportTypeMapping(type);
    CompilerParameters parameters = new CompilerParameters();
    Assembly xmlAssembly = XmlSerializer.GenerateSerializer(new Type[] { type }, new XmlMapping[] { mapping }, parameters);
