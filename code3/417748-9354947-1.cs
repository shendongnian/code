    public class ScriptHelper : IDisposable
    {
        bool _capturing = false;
        Queue<string> _list = new Queue<string>();
        readonly ViewContext _ctx;
        public ScriptHelper Capture()
        {
            _capturing = true;
            return this;
        }
        public IHtmlString Require(string scriptFile)
        {
            _list.Enqueue(scriptFile);
            if (!_capturing)
            {
                return Render();
            }
            return new HtmlString(String.Empty);
        }
        
        public IHtmlString Render()
        {
            IHtmlString scriptTags;
            //TODO: handle dependencies, order scripts, remove duplicates
            _list.Clear();
            return scriptTags;
        }
        public void Dispose()
        {
            _capturing = false;
            _ctx.Writer.Write(Render().ToHtmlString());
        }
    }
