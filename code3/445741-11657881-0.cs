    class AutoControllerDataAttribute : AutoDataAttribute
    {  
        public AutoControllerDataAttribute()
            : this( new Fixture() )
        {
        }
    
        public AutoControllerDataAttribute( IFixture fixture )
            : base( fixture )
        {
            fixture.Customize( new AutoMoqCustomization() );
            fixture.Customize( new ApplyControllerContextCustomization() );
        }
    
        class ApplyControllerContextCustomization : PostProcessWhereIsACustomization<Controller>
        {
            public ApplyControllerContextCustomization()
                : base( PostProcess )
            {
            }
    
            static void PostProcess( Controller controller )
            {
                controller.FakeControllerContext();
                // etc. - add stuff you want to happen after the instance has been created
