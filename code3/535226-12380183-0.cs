     public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            Get();
            return View();
        }
        public int Get()
        {
            throw new HttpException(404, "HTTP/1.1 404 Not Found");
            // we don't need end the response here, we need go to result step
            // currentContext.Response.End();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            if (filterContext.Exception is HttpException)
            {
                filterContext.Result = this.HttpNotFound(filterContext.Exception.Message);
            }
        }
