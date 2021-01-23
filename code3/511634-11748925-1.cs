    var csc = new CSharpCodeProvider( new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } } );
    var cp = new CompilerParameters() {
        GenerateExecutable = false,
        OutputAssembly = outputAssemblyName,
        GenerateInMemory = true
    };
    
    cp.ReferencedAssemblies.Add( "mscorlib.dll" );
    cp.ReferencedAssemblies.Add( "System.dll" );
    cp.ReferencedAssemblies.Add( "System.Core.dll" );
    
    StringBuilder sb = new StringBuilder();
    
    // The string can contain any valid c# code, but remember to resolve your references
    sb.Append( "namespace Foo{" );
    sb.Append( "using System;" );
    sb.Append( "public static class MyClass{");
    
    // your specific scenario
    sb.Append( @"public static readonly string[] LevelMap = {
        ""WWWWWWWWWWWWWWWWWWW"",
        ""WGGGGGGGGGGGGGGGGGW"",
        ""WGGGGGGGGGGGGGGGGGW"",
        ""WWWWWWWWWWWWWWWWWWW"" };" );
    sb.Append( "}}" );
    
    // "results" will usually contain very detailed error messages
    var results = csc.CompileAssemblyFromSource( cp, sb.ToString() );
