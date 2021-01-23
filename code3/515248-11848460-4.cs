            [HttpGet]
        public FileStreamResult GetEmbeddedResource(string pluginAssemblyName, string resourceName)
        {
            try
            {
                string physicalPath = Server.MapPath(pluginAssemblyName);
                Stream stream = ResourceHelper.GetEmbeddedResource(physicalPath, resourceName);
                return new FileStreamResult(stream, GetMediaType(resourceName));
                //return new FileStreamResult(stream, GetMediaType(tempResourceName));
            }
            catch (Exception)
            {
                return new FileStreamResult(new MemoryStream(), GetMediaType(resourceName));
            }
        }
        private string GetMediaType(string fileId)
        {
            if (fileId.EndsWith(".js"))
            {
                return "text/javascript";
            }
            else if (fileId.EndsWith(".css"))
            {
                return "text/css";
            }
            else if (fileId.EndsWith(".jpg"))
            {
                return "image/jpeg";
            }
            else if (fileId.EndsWith(".gif"))
            {
                return "image/gif";
            }
            else if (fileId.EndsWith(".png"))
            {
                return "image/png";
            }
            return "text";
        }
