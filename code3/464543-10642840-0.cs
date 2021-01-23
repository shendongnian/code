    var compilerHost = new IDECompilerHost();
    var typeEnumerator = (from compiler in compilerHost.Compilers.Cast<IDECompiler>()
                                              from type in compiler.GetCompilation().MainAssembly.Types
                                              select new Tuple<IDECompiler, CSharpType>(compiler, type));
    foreach (var typeTuple in typeEnumerator)
    {
        Trace.WriteLine(typeTuple.Item2.Name);
        var csType = typeTuple.Item2;
        foreach (var loc in csType.SourceLocations)
        {
           var file = loc.FileName.Value;
           var line = loc.Position.Line;
           var charPos = loc.Position.Character;
        }
    }
