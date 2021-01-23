    [TestMethod]
    public void ExecuteTest()
    {
        CodeDomProvider provider = provider = CodeDomProvider.CreateProvider("CSharp");
        CompilerParameters cp = new CompilerParameters();
        cp.GenerateExecutable = false;
        cp.GenerateInMemory = true;
        cp.TreatWarningsAsErrors = false;
        string source = @"using System; namespace N { public class C { public static DateTime Execute() { return DateTime.Now.AddDays(10); } } }";
        CompilerResults cr = provider.CompileAssemblyFromSource(cp, source);
        if(cr.Errors.Count > 0)
        {
            foreach(CompilerError ce in cr.Errors)
            {
                Console.Out.WriteLine("  {0}", ce.ToString());
            }
            Assert.Fail("Compilation error(s).");
        }
        else
        {
            object obj = cr.CompiledAssembly.CreateInstance("N.C");
            MethodInfo mi = obj.GetType().GetMethod("Execute", BindingFlags.Public | BindingFlags.Static);
            var actual = (DateTime)mi.Invoke(obj, null);
            Assert.IsNotNull(actual);
            var expected = DateTime.Now.AddDays(10).Date;
            Assert.AreEqual(expected, actual.Date);
        }
    }
