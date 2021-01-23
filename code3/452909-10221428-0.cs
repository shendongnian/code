    public class StringHolder
    {
        public int No;
        public string CustomerName;
        public string Action;
        public override string ToString()
        {
            return string.Format("No: {0} Customer: {1} Action: {2}", this.No, this.CustomerName, this.Action);
        }
    }
