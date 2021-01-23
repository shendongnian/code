    public class StringHolder
    {
        public int No;
        public string CustomerName;
        public string Action;
        public override string ToString()
        {
            return string.Format("No: {1}{0}Customer: {2}{0}Action: {3}",
                                 Environment.NewLine,
                                 this.No,
                                 this.CustomerName,
                                 this.Action);
        }
    }
