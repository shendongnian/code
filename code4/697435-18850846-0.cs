    var acci = this.Designer.Context.Items.GetValue<AssemblyContextControlItem>() ?? new AssemblyContextControlItem();
    acci.ReferencedAssemblyNames = acci.AllAssemblyNamesInContext
                                       .Select(an => new System.Reflection.AssemblyName(an))
                                       .Where(an => !an.Name.Contains(".resources"))
                                       .ToList();
    this.Designer.Context.Items.SetValue(acci);
