    abstract class DateItem
    {
        public DateTime DateTime { get; set; }
        public abstract virtual void DoSomething();
    }
    sealed class CreatedDate: DateItem
    {
        public override void DoSomething()
        {
            Console.WriteLine("Do something with CreatedDate");
        }
    }
    sealed class ExpiryDate: DateItem
    {
        public override void DoSomething()
        {
            Console.WriteLine("Do something with ExpiryDate");
        }
    }
