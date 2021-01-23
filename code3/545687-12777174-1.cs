    public class CustomFilter : MessageFilter
    {
        private int minSize;
        private int maxSize;
        public CustomFilter()
            : base()
        {
        }
        public CustomFilter(string paramlist)
            : base()
        {
            string[] sizes = paramlist.Split(new char[1] { ',' });
            minSize = Convert.ToInt32(sizes[0]);
            maxSize = Convert.ToInt32(sizes[1]);
        }
        public override bool Match(System.ServiceModel.Channels.Message message)
        {
            return true;
        }
        public override bool Match(MessageBuffer buffer)
        {
            return true;
        }
    }
