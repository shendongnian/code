    public abstract class MyControllerBase : Controller
    {
        // could be moved to web.config
        private const _jsonDataType = "JsonDataType";
        public bool IsAjaxRequest
        {
            get
            {
                return this.HttpContext.Request.IsAjaxRequest();
            }
        }
        public bool IsAjaxHtmlRequest
        {
            get
            {
                return string.Equals(this.Request.Headers[MyControllerBase._jsonDataType], "html", StringComparison.CurrentCultureIgnoreCase);
            }
        }
        private JsonResponse GetAjaxResponse()
        {
            JsonResponse result = new JsonResponse();
            result.IsValid = true;
            return result;
        }
        private JsonResponse<T> GetAjaxResponse<T>(T model)
        {
            JsonResponse<T> result = new JsonResponse<T>();
            result.Data = model;
            result.IsValid = true;
            return result;
        }
        private JsonResponse<string> GetAjaxHtmlResponse()
        {
            JsonResponse<string> result = new JsonResponse<string>();
            result.Data = this.PartialViewToString(this.ControllerContext.RouteData.Values["Action"].ToString(), null);
            result.IsValid = true;
            return result;
        }
        private JsonResponse<string> GetAjaxHtmlResponse<T>(T model)
        {
            JsonResponse<string> result = new JsonResponse<string>();
            result.Data = this.PartialViewToString(this.ControllerContext.RouteData.Values["Action"].ToString(), model);
            result.IsValid = true;
            return result;
        }
        private JsonResponse<string> GetAjaxHtmlResponse<T>(T model, string viewName)
        {
            JsonResponse<string> result = new JsonResponse<string>();
            result.Data = this.PartialViewToString(viewName, model);
            result.IsValid = true;
            return result;
        }
        public ActionResult ViewOrAjax()
        {
            return this.ViewOrAjax(JsonRequestBehavior.DenyGet);
        }
        public ActionResult ViewOrAjax(JsonRequestBehavior jsonRequestBehavior)
        {
            if (this.ControllerContext.IsChildAction)
            {
                return this.PartialView(this.ControllerContext.RouteData.Values["Action"].ToString(), null);
            }
            if (this.IsAjaxRequest)
            {
                if (this.IsAjaxHtmlRequest)
                {
                    return this.Json(this.GetAjaxHtmlResponse(), jsonRequestBehavior);
                }
                return this.Json(this.GetAjaxResponse(), jsonRequestBehavior);
            }
            return this.View(this.ControllerContext.RouteData.Values["Action"].ToString(), null);
        }
        public ActionResult ViewOrAjax<T>(T model)
        {
            return this.ViewOrAjax<T>(model, JsonRequestBehavior.DenyGet);
        }
        public ActionResult ViewOrAjax<T>(T model, JsonRequestBehavior jsonRequestBehavior)
        {
            if (this.ControllerContext.IsChildAction)
            {
                return this.PartialView(model);
            }
            if (this.IsAjaxRequest)
            {
                if (this.IsAjaxHtmlRequest)
                {
                    return this.Json(this.GetAjaxHtmlResponse(model), jsonRequestBehavior);
                }
                return this.Json(this.GetAjaxResponse<T>(model), jsonRequestBehavior);
            }
            return this.View(model);
        }
        public ActionResult ViewOrAjax<T>(IView view, T model, JsonRequestBehavior jsonRequestBehavior)
        {
            if (this.ControllerContext.IsChildAction)
            {
                return this.PartialView(model);
            }
            if (this.IsAjaxRequest)
            {
                if (this.IsAjaxHtmlRequest)
                {
                    return this.Json(this.GetAjaxHtmlResponse(model), jsonRequestBehavior);
                }
                return this.Json(this.GetAjaxResponse<T>(model), jsonRequestBehavior);
            }
            return this.View(view, model);
        }
        public ActionResult ViewOrAjax<T>(string viewName, T model)
        {
            return this.ViewOrAjax<T>(viewName, model, JsonRequestBehavior.DenyGet);
        }
        public ActionResult ViewOrAjax<T>(string viewName, T model, JsonRequestBehavior jsonRequestBehavior)
        {
            if (this.ControllerContext.IsChildAction)
            {
                return this.PartialView(model);
            }
            if (this.IsAjaxRequest)
            {
                if (this.IsAjaxHtmlRequest)
                {
                    return this.Json(this.GetAjaxHtmlResponse(model, viewName), jsonRequestBehavior);
                }
                return this.Json(this.GetAjaxResponse<T>(model), jsonRequestBehavior);
            }
            return this.View(viewName, model);
        }
        public ActionResult ViewOrAjax<T>(string viewName, string masterName, T model)
        {
            return this.ViewOrAjax<T>(viewName, masterName, model, JsonRequestBehavior.DenyGet);
        }
        public ActionResult ViewOrAjax<T>(string viewName, string masterName, T model, JsonRequestBehavior jsonRequestBehavior)
        {
            if (this.ControllerContext.IsChildAction)
            {
                return this.PartialView(model);
            }
            if (this.IsAjaxRequest)
            {
                if (this.IsAjaxHtmlRequest)
                {
                    return this.Json(this.GetAjaxHtmlResponse(model, viewName), jsonRequestBehavior);
                }
                return this.Json(this.GetAjaxResponse(model), jsonRequestBehavior);
            }
            return this.View(viewName, masterName, model);
        }
        protected internal new ViewResult View(string viewName, string masterName, object model)
        {
            if (model != null)
            {
                ViewData.Model = model;
            }
            ViewResult result = new ViewResult
            {
                ViewName = viewName,
                MasterName = masterName,
                ViewData = ViewData,
                TempData = TempData
            };
            return result;
        }
    }
