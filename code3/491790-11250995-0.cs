        /// <summary>
        /// Return full path of the IIS application
        /// </summary>
        public string FullyQualifiedApplicationPath
        {
            get
            {
                //Getting the current context of HTTP request
                var context = HttpContext.Current;
                //Checking the current context content
                if (context == null) return null;
                //Formatting the fully qualified website url/name
                var appPath = string.Format("{0}://{1}{2}{3}",
                                            context.Request.Url.Scheme,
                                            context.Request.Url.Host,
                                            context.Request.Url.Port == 80
                                                ? string.Empty
                                                : ":" + context.Request.Url.Port,
                                            context.Request.ApplicationPath);
                if (!appPath.EndsWith("/"))
                    appPath += "/";
                return appPath;
            }
        }
