    public abstract class RazorTemplateBase<dynamic>
    {
        public static string RootAddress { get; set; }
        public virtual RazorTemplateBase<dynamic> Layout { get; set; }
        private readonly StringBuilder generatingEnvironment = new StringBuilder();
        public abstract void Execute();
        public void WriteLiteral(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            generatingEnvironment.Append(textToAppend);
        }
        public void Write(object value)
        {
            if ((value == null))
            {
                return;
            }
            string stringValue;
            var t = value.GetType();
            var method = t.GetMethod("ToString", new [] { typeof(IFormatProvider) });
            if ((method == null))
            {
                stringValue = value.ToString();
            }
            else
            {
                stringValue = ((string)(method.Invoke(value, new object[] { CultureInfo.InvariantCulture })));
            }
            WriteLiteral(stringValue);
        }
        string content;
        public string RenderBody()
        {
            return content;
        }
        public string TransformText()
        {
            Execute();
            if (Layout != null)
            {
                Layout.content = generatingEnvironment.ToString();
                return Layout.TransformText();
            }
            else
            {
                return generatingEnvironment.ToString();
            }
        }
    }
