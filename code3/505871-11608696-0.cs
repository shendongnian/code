    public class Master
    {
        private Content _content;
        internal Content content
        {
            get
            {
                if (_content == null)
                {
                    _content = new Content(this);
                }
                return _content;
            }
        }
    }
