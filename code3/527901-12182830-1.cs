    public class Account
    {
        public string Name { get; private set; }
        public decimal[] MonthAmount { get; set; }
        public Account(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            this.Name = name;
            this.MonthAmount = new decimal[12];
        }
    }
