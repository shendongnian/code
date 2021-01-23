    public string GetAssemblyVersion(Assembly asm)
    {
      var attr = CustomAttributeExtensions.GetCustomAttribute<AssemblyFileVersionAttribute>(asm);
      if (attr != null)
        return attr.Version;
      else
        return "";
    }
