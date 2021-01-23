    namespace WPFBuildContentTest
    {
        class ContentProviderImplementation : IContentProvider
        {
            private static Assembly _CurrentAssembly;
            private Assembly CurrentAssembly
            {
                get
                {
                    if (_CurrentAssembly == null)
                    {
                        _CurrentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                    }
                    return _CurrentAssembly;
                }
            }
            public string LoadContent(string relativePath)
            {
                string localXMLUrl = Path.Combine(Path.GetDirectoryName(CurrentAssembly.GetName().CodeBase), relativePath);
                return File.ReadAllText(new Uri(localXMLUrl).LocalPath);
            }
        }
    }
