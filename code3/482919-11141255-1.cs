    using System.Diagnostics;
    using System.Linq;
    ...
    StackFrame[] frames = new StackTrace().GetFrames();
    string initialAssembly = (from f in frames 
                              select f.GetMethod().ReflectedType.AssemblyQualifiedName
                             ).Distinct().Last();
