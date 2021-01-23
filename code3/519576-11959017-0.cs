    public class WindsorCustomization : ICustomization
    {
        private readonly IWindsorContainer container;
        public WindsorCustomization()
        {
            // build this.container here using SUT installers
        }
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new WindsorAdapter(this.container));
        }
    }
    public WindsorAdapter : ISpecimenBuilder
    {
        private readonly IWindsorContainer container;
        public WindsorAdapter(IWindsorContainer container)
        {
            this.container = container;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;
            if (t == null || !this.container.Kernel.HasComponent(t))
                return new NoSpecimen(request);
            return this.container.Resolve(t);                
        }
    }
