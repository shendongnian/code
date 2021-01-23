    using Nancy;
    using Nancy.ModelBinding;
    
    namespace NancyFx
    {
        public class HomeModule : NancyModule
        {
            public HomeModule(IAppConfiguration appConfig)
            {
                Post("/product", args => {
                    dynamic product = Context.ToDynamic();
                    string name = product.Name;
                    decimal price = product.Price;
                    return Response.AsJson(new {IsValid=true, Message= "Product added sucessfully", Data = new {name, price} });
                });
            }
        }
    }
