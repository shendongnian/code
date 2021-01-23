            ViewEngines.Engines.Clear();
            var customEngine = new RazorViewEngine();
            customEngine.PartialViewLocationFormats = new string[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Partial/{0}.cshtml",
                "~/Views/Partial/{1}/{0}.cshtml"
            };
           
            customEngine.ViewLocationFormats = new string[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Controller/{1}/{0}.cshtml"
            };
            customEngine.MasterLocationFormats = new string[]
            {
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Layout/{0}.cshtml"
            };
            ViewEngines.Engines.Add(customEngine);
