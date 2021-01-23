    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
               if (filterContext.HttpContext.Request.IsAjaxRequest()) {
                            filterContext.HttpContext.Response.StatusCode = 403;
                        filterContext.Result = new JsonResult();
                        else
                            filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
                    }
                }
            }
