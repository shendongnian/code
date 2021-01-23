    public class EntityBaseProcessor<TEntityBase> : Processor<TEntityBase>
        where TEntityBase : EntityBase
    {
        public override void SetProcessors()
        {
            base.SetProcessors();
            this.Process(entity => entity.Name)
                .DoSomething();
        }
    }
    
    public class EntityChildProcessor : EntityBaseProcessor<EntityChild>
    {
        public override void SetProcessors()
        {
            base.SetProcessors();
            this.Process(entity => entity.Description)
                .DoSomething();
        }
    }
