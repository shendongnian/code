public class MainClass
public static void Called()
    var csc = new CSharpCodeProvider();
    var ca = Assembly.GetExecutingAssembly();
    var cp = new CompilerParameters();
    cp.GenerateInMemory = true;
    cp.ReferencedAssemblies.Add("System.dll");
    cp.ReferencedAssemblies.Add("mscorlib.dll");
    cp.ReferencedAssemblies.Add(ca.Location);
    var res = csc.CompileAssemblyFromSource(
        cp,
        @"using System; 
            public class TestClass
            { 
                public int testvar = 5;
                public string Execute() 
                { 
                    scriptingTest.MainClass.Called();
                    return ""Executed."";
                }
            }"
    );
