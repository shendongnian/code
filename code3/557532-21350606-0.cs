    using FluentValidation.Mvc.WebApi;
    
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ...
            FluentValidationModelValidatorProvider.Configure();
        }
    }
