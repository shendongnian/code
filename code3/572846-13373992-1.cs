    public class AutoMockingContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            var strategy = new AutoMockingBuilderStrategy(Container);
    
            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
        }
    
        class AutoMockingBuilderStrategy : BuilderStrategy
        {
            private readonly IUnityContainer container;
            private readonly Dictionary<Type, object> substitutes 
               = new Dictionary<Type, object>();
    
            public AutoMockingBuilderStrategy(IUnityContainer container)
            {
                this.container = container;
            }
    
            public override void PreBuildUp(IBuilderContext context)
            {
                var key = context.OriginalBuildKey;
    
                if (key.Type.IsInterface && !container.IsRegistered(key.Type))
                {
                    context.Existing = GetOrCreateSubstitute(key.Type);
                    context.BuildComplete = true;
                }
            }
    
            private object GetOrCreateSubstitute(Type type)
            {
                if (substitutes.ContainsKey(type))
                    return substitutes[type];
    
                var substitute = Substitute.For(new[] {type}, null);
    
                substitutes.Add(type, substitute);
    
                return substitute;
            }
        }
    }
