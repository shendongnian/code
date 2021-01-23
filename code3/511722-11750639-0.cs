    cp.ReferencedAssemblies.Add( "mscorlib.dll" );
    cp.ReferencedAssemblies.Add( "System.dll" );
    
    StringBuilder sb = new StringBuilder();
    
    // The string can contain any valid c# code
    
    sb.Append( "namespace Foo{" );
    sb.Append( "using System;" );
    sb.Append( "public static class MyClass{");
    sb.Append( "}}" );
