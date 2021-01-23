    public NinjectRazorViewEngine(): base()
        {
            ViewLocationFormats = new[] {
                "~/Modules/{2}/Views/{1}/{0}.cshtml",
                "~/Modules/{2}/Views/{1}/{0}.vbhtml",
                "~/Modules/{2}/Views/Shared/{0}.cshtml",
                "~/Modules/{2}/Views/Shared/{0}.vbhtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };
            MasterLocationFormats = new[] {
                "~/Modules/{2}/Views/{1}/{0}.cshtml",
                "~/Modules/{2}/Views/{1}/{0}.vbhtml",
                "~/Modules/{2}/Views/Shared/{0}.cshtml",
                "~/Modules/{2}/Views/Shared/{0}.vbhtml",
            };
            PartialViewLocationFormats = new[] {
                "~/Modules/{2}/Views/{1}/{0}.cshtml",
                "~/Modules/{2}/Views/{1}/{0}.vbhtml",
                "~/Modules/{2}/Views/Shared/{0}.cshtml",
                "~/Modules/{2}/Views/Shared/{0}.vbhtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };
            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
            //Used to test cache
            //ViewLocationCache = new DefaultViewLocationCache();
        }
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return FindView(controllerContext, partialViewName, "", useCache);
        }
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            //Implement defualt exceptions
            if(controllerContext == null)
                throw new ArgumentNullException("The controllerContext parameter is null");
            if(string.IsNullOrEmpty(viewName))
                throw new ArgumentException("The viewName parameter is null or empty.");
            //Check cache if specified
            if(useCache && this.ViewLocationCache != null){
                string cachedLocation = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, generateCacheKey(controllerContext, viewName));
                if (!string.IsNullOrEmpty(cachedLocation))
                    return new ViewEngineResult(CreateView(controllerContext, cachedLocation, masterName), this);
            }
            //Create arguments for location formatting
            string trimmedViewName = string.Empty;
            if (viewName.EndsWith(".cshtml"))
                trimmedViewName = viewName.Remove(viewName.Length - 7);
            else
                trimmedViewName = viewName;
            object[] args = new object[] { trimmedViewName, controllerContext.RouteData.GetRequiredString("controller"), controllerContext.RouteData.GetRequiredString("module") };
            //Attempt to locate file
            List<string> searchedLocations = new List<string>();
            foreach(string location in ViewLocationFormats){
                string formatedLocation = string.Format(location,args);
                searchedLocations.Add(formatedLocation);
                if (FileExists(controllerContext, formatedLocation))
                {
                    //File has been found. Add to cache and return view
                    if(this.ViewLocationCache != null)
                        ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, generateCacheKey(controllerContext, viewName), formatedLocation);
                    return new ViewEngineResult(CreateView(controllerContext, formatedLocation, masterName), this);
                }
            }
            //Couldnt find view, return searched locations
            return new ViewEngineResult(searchedLocations);
        }
        public string generateCacheKey(ControllerContext controllerContext, string viewName)
        {
            return string.Format("{0}|{1}", controllerContext.RouteData.GetRequiredString("module"), viewName);
        }
