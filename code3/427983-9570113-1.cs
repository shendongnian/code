    [Subject(typeof(MvcApplication))]
    public class when_application_starts : mvc_application_spec
    {
        protected static MvcApplication application;
        protected static bool areas_registered;
        Establish context = () => application = new MvcApplicationProxy();
        Because of = () => application.Application_Start();
        It should_register_mvc_areas = () => areas_registered.ShouldBeTrue();
        class MvcApplicationProxy : MvcApplication
        {
            protected override void RegisterAllAreas()
            {
                areas_registered = true;
            }
        }
    }
