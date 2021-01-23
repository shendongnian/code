      public static class CustomExtensions {
    
            public static IDisposable Step<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression) {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
                TextWriter writer = html.ViewContext.Writer;
                writer.WriteLine("<div class=\"editable\" id=\"{0}\">",metadata.PropertyName);
                writer.WriteLine(metadata.Model.ToString());
                return new CreationSteps(html, metadata);
            }
    
            private class CreationSteps : IDisposable {
    
                #region | Properties |
                private readonly TextWriter writer;
                private bool disposed;
                private ModelMetadata _metadata;
                #endregion
     
                /// <summary>
                /// Initialize a new instance of <see cref="CreationSteps"/>
                /// </summary>
                /// <param name="html"></param>
                /// <param name="metadata"></param>
                public CreationSteps(HtmlHelper html, ModelMetadata metadata) {
                    this._metadata = metadata;
                    this.writer = html.ViewContext.Writer;
                }
    
                #region | Public Methods |
                public void Dispose() {
                    if (disposed) return;
                    disposed = true;
                    writer.WriteLine("</div>");
                }
                #endregion
      
            }
        }
