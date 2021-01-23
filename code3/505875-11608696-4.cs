    public class Master
    {
        internal Content content
        {
            get; private set;
        }
        internal Content GetOrCreateContent()
        {
            if (content == null)
            {
                content = new Content(this);
            }
            return content;
        }
        internal Master()
        {
        }
    }
