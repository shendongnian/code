    public class ReturnJsonIfAcceptedAttribute : ActionFilterAttribute
    {
        private bool _onAjaxOnly;
        private bool _allowJsonOnGet;
        public ReturnJsonIfAcceptedAttribute(bool onAjaxOnly = true, bool allowJsonOnGet = false)
        {
            _onAjaxOnly = onAjaxOnly;
            _allowJsonOnGet = allowJsonOnGet;
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (!_allowJsonOnGet && request.HttpMethod.ToUpper() == "GET")
                return;
            var isAjax = !_onAjaxOnly || request.IsAjaxRequest();
            if (isAjax && request.AcceptTypes.Contains("json", StringComparer.OrdinalIgnoreCase))
            {
                var viewResult = filterContext.Result as ViewResult;
                if (viewResult == null)
                    return;
                var jsonResult = new JsonResult();
                jsonResult.Data = viewResult.Model;
                filterContext.Result = jsonResult;
            }
        }
