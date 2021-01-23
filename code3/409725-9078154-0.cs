    public class ContextDisposer : IHttpModule
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        public void Init(HttpApplication context)
        {
            context.EndRequest += (sender, e) => this.DisposeContext(sender, e);
        }
        private static bool DoesRequestCompletionRequireDisposing(
            string requestPath)
        {
            string fileExtension = Path.GetExtension(requestPath)
                .ToUpperInvariant();
            switch (fileExtension)
            {
                case ".ASPX":
                case string.Empty:
                case null:
                    return true;
            }
            return false;
        }
        private void DisposeContext(object sender, EventArgs e)
        {
            // This gets fired for every request to the server, but there's no 
            // point trying to dispose anything if the request is for (e.g.) a 
            // gif, so only call Dispose() if necessary:
            string requestedFilePath = ((HttpApplication)sender).Request.FilePath;
            if (DoesRequestCompletionRequireDisposing(requestedFilePath))
            {
                this._context.Dispose();
            }
        }
    }
