    namespace MvcApplication1.Areas.Test
    {
    public class TestAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Test";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            //This line breaks the functionality in the area registration.
            context.MapRoute(
                "Test_default", // Route name
                "Test/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Test", action = "Index", id = "" }, // Parameter defaults
                new string[] { "MvcApplication1.Areas.Test.Controllers" } //namespace
                );
        }
    }
    }
