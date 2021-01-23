    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Razor;
    using Microsoft.CSharp;
    
    namespace YourNamespace.Specifications.SpecUtils
    {
        public sealed class InMemoryRazorEngine
        {
            public static ExecutionResult Execute<TModel>(string razorTemplate, TModel model, params Assembly[] referenceAssemblies)
            {
                var razorEngineHost = new RazorEngineHost(new CSharpRazorCodeLanguage());
                razorEngineHost.DefaultNamespace = "RazorOutput";
                razorEngineHost.DefaultClassName = "Template";
                razorEngineHost.NamespaceImports.Add("System");
                razorEngineHost.DefaultBaseClass = typeof(RazorTemplateBase<TModel>).FullName;
    
                var razorTemplateEngine = new RazorTemplateEngine(razorEngineHost);
    
                using (var template = new StringReader(razorTemplate))
                {
                    var generatorResult = razorTemplateEngine.GenerateCode(template);
    
                    var compilerParameters = new CompilerParameters();
                    compilerParameters.GenerateInMemory = true;
                    compilerParameters.ReferencedAssemblies.Add(typeof(InMemoryRazorEngine).Assembly.Location);
                    if (referenceAssemblies != null)
                    {
                        foreach (var referenceAssembly in referenceAssemblies)
                        {
                            compilerParameters.ReferencedAssemblies.Add(referenceAssembly.Location);
                        }
                    }
    
                    var codeProvider = new CSharpCodeProvider();
                    var compilerResult = codeProvider.CompileAssemblyFromDom(compilerParameters, generatorResult.GeneratedCode);
    
                    var compiledTemplateType = compilerResult.CompiledAssembly.GetExportedTypes().Single();
                    var compiledTemplate = Activator.CreateInstance(compiledTemplateType);
    
                    var modelProperty = compiledTemplateType.GetProperty("Model");
                    modelProperty.SetValue(compiledTemplate, model, null);
    
                    var executeMethod = compiledTemplateType.GetMethod("Execute");
                    executeMethod.Invoke(compiledTemplate, null);
    
                    var builderProperty = compiledTemplateType.GetProperty("OutputBuilder");
                    var outputBuilder = (StringBuilder)builderProperty.GetValue(compiledTemplate, null);
                    var runtimeResult = outputBuilder.ToString();
    
                    return new ExecutionResult(generatorResult, compilerResult, runtimeResult);
                }
            }
            #region Nested type: ExecutionResult
    
            public sealed class ExecutionResult
            {
                public ExecutionResult(GeneratorResults generatorResult, CompilerResults compilerResult, string runtimeResult)
                {
                    GeneratorResult = generatorResult;
                    CompilerResult = compilerResult;
                    RuntimeResult = runtimeResult;
                }
    
                public GeneratorResults GeneratorResult { get; private set; }
                public CompilerResults CompilerResult { get; private set; }
                public string RuntimeResult { get; private set; }
            }
    
            #endregion
    
            #region Nested type: RazorTemplateBase
    
            public abstract class RazorTemplateBase<TModel>
            {
                protected RazorTemplateBase()
                {
                    OutputBuilder = new StringBuilder();
                }
    
                public TModel Model { get; set; }
                public StringBuilder OutputBuilder { get; private set; }
    
                public abstract void Execute();
    
                public virtual void Write(object value)
                {
                    OutputBuilder.Append(value);
                }
    
                public virtual void WriteLiteral(object value)
                {
                    OutputBuilder.Append(value);
                }
            }
    
            #endregion
        }
    }
