    public class FacebookGroupViewModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var model = new FacebookGroupViewModel();
                if(controllerContext.HttpContext.Request.Form.AllKeys.Contains("Friends"))
                {
                    var friends = controllerContext.HttpContext.Request.Form["Friends"].Split(',');
                    foreach (var friend in friends)
                    {
                        model.FacebookFriendIds.Add(friend);
                    }
           
     }
                return model;
            }
        }
