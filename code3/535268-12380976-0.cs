        public class DependencyViewEngine : RazorViewEngine
        {
            public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
            {
                var result = base.FindPartialView(controllerContext, partialViewName, useCache);
                result.ViewEngine = // resolve view engine
                return result;
            }
            public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
            {
                var result = base.FindView(controllerContext, viewName, masterName, useCache);
                result.ViewEngine = // resolve view engine
                return result;
            }
        }
