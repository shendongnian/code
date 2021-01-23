    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.IO;
    using System.Diagnostics;
    
    namespace ILCompileTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string ASSEMBLY_NAME = "IL_Test";
    
                AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    new AssemblyName(ASSEMBLY_NAME), AssemblyBuilderAccess.Save);
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(
                    ASSEMBLY_NAME, "test.exe");
                TypeBuilder typeBuilder = moduleBuilder.DefineType("Program", 
                    TypeAttributes.Class | TypeAttributes.Public);
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    "Main", MethodAttributes.HideBySig|MethodAttributes.Public | MethodAttributes.Static,
                    typeof(void), new Type[] { typeof(string[]) });
                ILGenerator gen = methodBuilder.GetILGenerator();
    
                gen.Emit(OpCodes.Ldstr, "Hello, World!");
                gen.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
                gen.Emit(OpCodes.Ldc_I4_1);
                gen.Emit(OpCodes.Call, typeof(Console).GetMethod("ReadKey", new Type[] { typeof(bool) }));
                typeBuilder.CreateType();
                assemblyBuilder.SetEntryPoint(methodBuilder, PEFileKinds.ConsoleApplication);
                File.Delete("test.exe");
                assemblyBuilder.Save("test.exe");
    
                Process.Start("test.exe");
            }
        }
    }
 
