    public partial class Station_Master
    {
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "Active";
                    case 1:
                        return "Inactive";
                    default:
                        return "Unknown";
                }
            }
        }
    }
