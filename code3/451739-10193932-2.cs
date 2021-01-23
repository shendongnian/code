    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MyProject.Helpers
    {
        public enum Asset
        {
            Grid=1,
            FileUpload=2
        }
        public static class Helper
        {
            
            public static void RequireAssets(this HtmlHelper helper, params Asset[] assets)
            {
                var alreadyRequired = helper.ViewData["RequiredAssets"] as List<Asset>;
                if (alreadyRequired == null)
                {
                    alreadyRequired = new List<Asset>();
                    helper.ViewData.Add("RequiredAssets", alreadyRequired);
                }
    
                foreach (var asset in assets.Where(anAsset => !alreadyRequired.Contains(anAsset)))
                    alreadyRequired.Add(asset);
            }
    
            // Used in the layout view
            public static MvcHtmlString RenderAssetStyles(this HtmlHelper helper)
            {
                var requiredAssets = helper.ViewData["RequiredAssets"] as List<Asset>;
                return requiredAssets == null ? null : MvcHtmlString.Create("Test Style");
            }
    
            public static MvcHtmlString RenderAssetScripts(this HtmlHelper helper)
            {
                var requiredAssets = helper.ViewData["RequiredAssets"] as List<Asset>;
                return requiredAssets == null ? null : MvcHtmlString.Create("Test Script");
            }
        }
    
    }
