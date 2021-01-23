    using System;
    using System.Activities;
    using System.Activities.Expressions;
    using System.Activities.Statements;
    using System.Activities.XamlIntegration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xaml;
    using ExternalNamespace;
    using Microsoft.CSharp.Activities;
    
    namespace CSharpExpression 
    {
        class Program
        {
            static void Main()
            {
                var errorCodeWorkflow = new DynamicActivity
                {
                    Name = "MyScenario.MyDynamicActivity3",
                    Properties =
                    {
                        new DynamicActivityProperty
                        {
                            Name = "Address",
                            Type = typeof(InArgument<MailAddress>),
                        },
                    },
                    Implementation = () => new WriteLine
                    {
                        Text = new CSharpValue<String>
                        {
                            ExpressionText = "\"MyDynamicActivity \" + Address.DisplayName"
                        }
                    }
                };
    
                var impl = new AttachableMemberIdentifier(typeof(TextExpression), "NamespacesForImplementation");
                var namespaces = new List<string> { typeof(MailAddress).Namespace };
                TextExpression.SetReferencesForImplementation(errorCodeWorkflow, new AssemblyReference { Assembly = typeof(MailAddress).Assembly });
                AttachablePropertyServices.SetProperty(errorCodeWorkflow, impl, namespaces);
    
                CompileExpressions(errorCodeWorkflow);
                WorkflowInvoker.Invoke(errorCodeWorkflow, new Dictionary<String, Object> { { "Address", new MailAddress { DisplayName = "TestDisplayName" } } });
            }
    
            static void CompileExpressions(DynamicActivity dynamicActivity)
            {
                var activityName = dynamicActivity.Name;
                var activityType = activityName.Split('.').Last() + "_CompiledExpressionRoot";
                var activityNamespace = string.Join(".", activityName.Split('.').Reverse().Skip(1).Reverse());
    
                var settings = new TextExpressionCompilerSettings
                {
                    Activity = dynamicActivity,
                    Language = "C#",
                    ActivityName = activityType,
                    ActivityNamespace = activityNamespace,
                    RootNamespace = "CSharpExpression",
                    GenerateAsPartialClass = false,
                    AlwaysGenerateSource = true,
                    ForImplementation = true
                };
    
                var results = new TextExpressionCompiler(settings).Compile();
    
                if (results.HasErrors)
                {
                    throw new Exception("Compilation failed.");
                }
    
                var compiledExpressionRoot = Activator.CreateInstance(results.ResultType, new object[] { dynamicActivity }) as ICompiledExpressionRoot;
                CompiledExpressionInvoker.SetCompiledExpressionRootForImplementation(dynamicActivity, compiledExpressionRoot);
            }
        }
    }
    
    namespace ExternalNamespace
    {
        public class MailAddress
        {
            public String Address { get; set; }
            public String DisplayName { get; set; }
        }
    }
