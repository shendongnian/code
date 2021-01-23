    ...
    CecilLoader loader = new CecilLoader();
    Assembly[] assembliesToLoad = {
        ...
        typeof(System.Data.Linq.Mapping.ColumnAttribute).Assembly
        ...};
    
    IUnresolvedAssembly[] projectAssemblies = new IUnresolvedAssembly[assembliesToLoad.Length];
    for(int i = 0; i < assembliesToLoad.Length; i++)
    {
        projectAssemblies[i] = loader.LoadAssemblyFile(assembliesToLoad[i].Location);
    }
    
    IProjectContent project = new CSharpProjectContent();
    project = project.AddAssemblyReferences(projectAssemblies);
    ...
