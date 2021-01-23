    public class CSVValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var uploadedFiles = controllerContext.HttpContext.Request.Files;
            
            if (uploadedFiles.Count > 0)
            {
                var file = uploadedFiles[0];
                var extension = file.FileName.Split('.').Last();
                
                if (extension.Equals("csv", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (file.ContentLength > 0)
                    {
                        var stream = file.InputStream;
                        var csvReader = new CSVReader(new StreamReader(stream, Encoding.Default, true));
                        return new CSVValueProvider(controllerContext, csvReader);
                    }
                }
            }
            return null;
        }
    }
