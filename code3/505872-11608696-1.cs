    public class Master
    {
        internal Content content
        {
            get; private set;
        }
        internal Master()
        {
            content = new Content(this);
        }
    }
