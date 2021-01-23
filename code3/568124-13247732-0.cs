    public class CustomDataHandler : ICustomData
    {
        private string customData;
    
        public string CustomData
        {
            get
            {
                return customData;
            }
            set
            {
                customData = value;
            }
        }
    }
