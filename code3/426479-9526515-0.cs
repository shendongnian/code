    public class MyClass
    {
        public DateTime MyDate { get; set; }
        
        public void AddDays(double days)
        {
            this.MyDate = this.MyDate.AddDays(days);
        }
    }
