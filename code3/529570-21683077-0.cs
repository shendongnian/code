    // It's very important this is named Generator.SpecflowPlugin.
    namespace MyGenerator.Generator.SpecflowPlugin
    {
        public class MyGeneratorProvider : MsTest2010GeneratorProvider
        {
            public MyGeneratorProvider(CodeDomHelper codeDomHelper)
                : base(codeDomHelper)
            {
            }
    
             public override void SetTestClassInitializeMethod(TestClassGenerationContext generationContext)
            {
           
                base.SetTestClassInitializeMethod(generationContext);
    
    generationContext.TestClassInitializeMethod.Statements.Add(new CodeSnippetStatement(
                                                                          @"TargetDataDeploymentRoot = context.TestDeploymentDir;"));
    
            }
    
         }
    
    
    [assembly: GeneratorPlugin(typeof(MyGeneratorPlugin))]
    
        public class MyGeneratorPlugin : IGeneratorPlugin
        {
            public void RegisterDependencies(ObjectContainer container)
            {
            }
    
            public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
            {
                container.RegisterTypeAs<MyGeneratorProvider, IUnitTestGeneratorProvider>();
            }
            
            public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
            {
            }
        }
    
    }
