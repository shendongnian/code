	public class CustomViewEngine: ThemeableRazorViewEngine {
        private readonly string[] _emptyLocations = null;
        
        public CustomViewEngine() {
            PartialViewLocationFormats = new[] {
				"~/Administration/CustomExtension/Views/{1}/{0}.cshtml",
				"~/Administration/CustomExtension/Views/Shared/{0}.cshtml"
			};
            ViewLocationFormats = new[] {
				"~/Administration/CustomExtension/Views/{1}/{0}.cshtml",
				"~/Administration/CustomExtension/Views/Shared/{0}.cshtml"
			};
        }
        
        protected override string GetPath(ControllerContext controllerContext, string[] locations, string[] areaLocations, string locationsPropertyName, string name, string controllerName, string theme, string cacheKeyPrefix, bool useCache, out string[] searchedLocations) {
            searchedLocations = _emptyLocations;
            if (string.IsNullOrEmpty(name)) {
                return string.Empty;
            }
            string areaName = GetAreaName(controllerContext.RouteData);
            //little hack to get nop's admin area to be in /Administration/ instead of /Nop/Admin/ or Areas/Admin/
            if (!string.IsNullOrEmpty(areaName) && areaName.Equals("admin", StringComparison.InvariantCultureIgnoreCase)) {
                var newLocations = areaLocations.ToList();
                newLocations.Insert(0, "~/Administration/Views/{1}/{0}.cshtml");
                newLocations.Insert(0, "~/Administration/Views/Shared/{0}.cshtml");
				
				//Insert your custom View locations to the top of the list to be given a higher precedence
                newLocations.Insert(0, "~/Administration/CustomExtension/Views/{1}/{0}.cshtml");
                newLocations.Insert(0, "~/Administration/CustomExtension/Views/Shared/{0}.cshtml");
                areaLocations = newLocations.ToArray();
            }
            bool flag = !string.IsNullOrEmpty(areaName);
            List<ViewLocation> viewLocations = GetViewLocations(locations, flag ? areaLocations : null);
            if (viewLocations.Count == 0) {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Properties cannot be null or empty.", new object[] { locationsPropertyName }));
            }
            bool flag2 = IsSpecificPath(name);
            string key = CreateCacheKey(cacheKeyPrefix, name, flag2 ? string.Empty : controllerName, areaName, theme);
            if (useCache) {
                var cached = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
                if (cached != null) {
                    return cached;
                }
            }
            if (!flag2) {
                return GetPathFromGeneralName(controllerContext, viewLocations, name, controllerName, areaName, theme, key, ref searchedLocations);
            }
            return GetPathFromSpecificName(controllerContext, name, key, ref searchedLocations);
        }
    }
