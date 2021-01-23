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
            }
        }
    }
