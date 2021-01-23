        private static Stream GetResourceStream(string resourcePath)
        {
            try
            {
                string s = System.IO.Packaging.PackUriHelper.UriSchemePack;
                var uri = new Uri(resourcePath);
                StreamResourceInfo sri = System.Windows.Application.GetResourceStream(uri);
                return sri.Stream;
            }
            catch (Exception e)
            {
                return null;
            }
        }
