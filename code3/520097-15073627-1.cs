    public class CustomStyleBundle : Bundle
        {
            public CustomStyleBundle(string virtualPath, IBundleTransform bundleTransform = null)
                : base(virtualPath, new IBundleTransform[1]
                    {
                        bundleTransform ?? new CustomCssMinify()
                    })
            {
            }
    
            public CustomStyleBundle(string virtualPath, string cdnPath, IBundleTransform bundleTransform = null)
                : base(virtualPath, cdnPath, new IBundleTransform[1]
                    {
                        bundleTransform ?? new CustomCssMinify()
                    })
            {
            }
        }
    
    public class CustomCssMinify : IBundleTransform
        {
            private const string CssContentType = "text/css";
    
            static CustomCssMinify()
            {
            }
    
            public virtual void Process(BundleContext context, BundleResponse response)
            {
                if (context == null)
                    throw new ArgumentNullException("context");
                if (response == null)
                    throw new ArgumentNullException("response");
                if (!context.EnableInstrumentation)
                {
                    var minifier = new Minifier();
                    FixCustomCssErrors(response);
                    string str = minifier.MinifyStyleSheet(response.Content, new CssSettings()
                    {
                        CommentMode = CssComment.None
                    });
                    if (minifier.ErrorList.Count > 0)
                        GenerateErrorResponse(response, minifier.ErrorList);
                    else
                        response.Content = str;
                }
                response.ContentType = CssContentType;
            }
    
            /// <summary>
            /// Add some extra fixes here
            /// </summary>
            /// <param name="response">BundleResponse</param>
            private void FixCustomCssErrors(BundleResponse response)
            {
                response.Content = Regex.Replace(response.Content, @"@import[\s]+([^\r\n]*)[\;]", String.Empty, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }
    
            private static void GenerateErrorResponse(BundleResponse bundle, IEnumerable<object> errors)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("/* ");
                stringBuilder.Append("CSS Minify Error").Append("\r\n");
                foreach (object obj in errors)
                    stringBuilder.Append(obj.ToString()).Append("\r\n");
                stringBuilder.Append(" */\r\n");
                stringBuilder.Append(bundle.Content);
                bundle.Content = stringBuilder.ToString();
            }
        }
