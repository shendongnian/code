    public class SomeViewModelBuilder : IViewModelBuilder<SomeViewModelBuilderArgs>
    {
        public class SomeViewModelBuilderArgs 
        {
            public SomeEntity Entity1 { get; private set; }
            public SomeOtherEntity Entity2 { get; private set; }
            public SomeViewModelBuilderArgs(Entity1 someEntity, Entity2 someOtherEntity) 
            {
                SomeEntity = someEntity;
                SomeOtherEntity = someOtherEntity;
            }
        }
        public SomeViewModel Build(SomeViewModelBuilderArgs)
        {
            // Do work
            return new SomeViewModel();
        }
    }
