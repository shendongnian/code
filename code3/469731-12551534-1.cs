        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var formData = actionContext.ActionArguments["formData"] as FormDataCollection;
            if (formData != null)
            {
                var userID = formData.Get("UserID");
                var accessToken = formData.Get("AccessToken");
                // authorize
            }
            base.OnActionExecuting(actionContext);
        }
