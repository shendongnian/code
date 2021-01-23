    internal class Message
    {
        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set 
            {
                if (string.IsNullOrEmpty(title))
                    title = value;
                else
                    throw new InvalidOperationException("Title can be set only once!");
            }
        }
    }
