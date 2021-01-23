    public class TheViewModelBinder : IModelBinder {
        public object BindModel( ControllerContext controllerContext, ModelBindingContext     bindingContext ) {
                        var theViewModel = new TheViewModel();
                        theViewModel.SiteId = int.Parse(request.Form.Get( "SiteId" ));
                        //other your code here
                }
        }
