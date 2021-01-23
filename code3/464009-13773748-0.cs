    /// <summary>Generates an identifier for the assembly of a specified type</summary>
    /// <remarks>Code copied from the .NET serialization classes - to emulate the same bahavior</remarks>
    /// <param name="type">The type</param>
    /// <returns>String identifying the type's assembly</returns>
    static string GenerateAssemblyId(Type type) 
    { 
      Module[] modules = type.Assembly.GetModules();
      ArrayList list = new ArrayList();
      for (int i = 0; i < modules.Length; i++) {
        list.Add(modules[i].ModuleVersionId.ToString()); 
      }
      list.Sort(); 
      StringBuilder sb = new StringBuilder(); 
      for (int i = 0; i < list.Count; i++) {
        sb.Append(list[i].ToString()); 
        sb.Append(",");
      }
      return sb.ToString();
    } // GenerateAssemblyId
    /// <summary>Verifies that the serialization assembly for the specified type can be loaded</summary>
    /// <remarks>Code copied from the .NET serialization classes - to emulate the same behavior and tests</remarks>
    /// <param name="type">The type</param>
    static void AssertCanLoadXmlSerializers(Type type)
    {
      if (type == null)
        throw new ArgumentNullException("type");
      Assembly serializerAssembly = null;
      // Create the name of the XML serilizers assembly from the type's one
      AssemblyName name = type.Assembly.GetName(true); 
      name.Name = name.Name + ".XmlSerializers"; 
      name.CodeBase = null;
      name.CultureInfo = CultureInfo.InvariantCulture;
      try {
        serializerAssembly = Assembly.Load(name);
      } catch (Exception e) {
        Assert.Fail("Unable to load XML serialization assembly for type '{0}': {1}", type.FullName, e.Message);
      }
      object[] attrs = serializerAssembly.GetCustomAttributes(typeof(XmlSerializerVersionAttribute), false);
      if (attrs == null || attrs.Length == 0) {
        Assert.Fail(
          "Unable to use XML serialization assembly '{1}' for type '{0}': it does not contain XmlSerializerVersionAttribute", 
          type.FullName, 
          serializerAssembly.FullName
        );
      }
      if (attrs.Length > 1) {
        Assert.Fail(
          "Unable to use XML serialization assembly '{1}' for type '{0}': it contains multiple XmlSerializerVersionAttribute", 
          type.FullName, 
          serializerAssembly.FullName
        );
      }
      XmlSerializerVersionAttribute assemblyInfo = (XmlSerializerVersionAttribute)attrs[0];
      string assemblyId = GenerateAssemblyId(type);
      if (assemblyInfo.ParentAssemblyId != assemblyId) {
        Assert.Fail(
          "Unable to use XML serialization assembly '{1}' for type '{0}': it does not match assembly id '{2}'", 
          type.FullName, 
          serializerAssembly.FullName,
          assemblyId
        );
      }
    } // AssertCanLoadXmlSerializers
