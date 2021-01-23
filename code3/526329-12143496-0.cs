    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.CodeDom;
    public static Assembly CreateFromCSFiles(string pathName)
    {
            CSharpCodeProvider csCompiler = new CSharpCodeProvider();
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            // here you must add all the references you need. 
            // I don't know whether you know all of them, but you have to get them
            // someway, otherwise it can't work
            compilerParams.ReferencedAssemblies.Add("system.dll");
            compilerParams.ReferencedAssemblies.Add("system.Data.dll");
            compilerParams.ReferencedAssemblies.Add("system.Windows.Forms.dll");
            compilerParams.ReferencedAssemblies.Add("system.Drawing.dll");
            compilerParams.ReferencedAssemblies.Add("system.Xml.dll");
            DirectoryInfo csDir = new DirectoryInfo(pathName);
            FileInfo[] files = csDir.GetFiles();
            string[] csPaths = new string[files.Length];
            foreach (int i = 0; i < csPaths.Length; i++)
                csPaths[i] = files[i].FullName;
            CompilerResults result = csCompiler.CompileAssemblyFromFile(compilerParams, csPaths);
            if (result.Errors.HasErrors)
                return null;
            return result.CompiledAssembly;
    }
