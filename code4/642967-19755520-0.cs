    private static string GetUserResourceString(ControllerContext controllerContext, string resourceName)
            {
                string result = null;
    
                if (!String.IsNullOrEmpty(ResourceClassKey) && (controllerContext != null) && (controllerContext.HttpContext != null))
                {
                    //result = controllerContext.HttpContext.GetGlobalResourceObject(ResourceClassKey, resourceName, CultureInfo.CurrentUICulture) as string;
                    result = GlobalRes.ResourceManager.GetString(resourceName);
                }
    
                return result;
            }
