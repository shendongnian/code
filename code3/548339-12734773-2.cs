    var assemblies = Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies()
        .Select(a => Assembly.ReflectionOnlyLoad(a.FullName))
        .Select(a => new 
          { Asm = a, 
            CustomAttributeDataList = CustomAttributeData.GetCustomAttributes(a)
          })
        .Where(x => x.CustomAttributeDataList.Any(y => y.AttributeType ==           
             type(AssemblyCategoryAttribute)))
        .Select(x => x.Asm)
        .ToList();
