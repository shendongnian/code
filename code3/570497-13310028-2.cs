    public class InsulineInjection
    {
        protected InsulineInjection()
        {
            // works with many OR/Ms
        }
    
        public InsulineInjection(Millilitre millilitre, DateTime dateTime, string remark)
        {
            this.Remark = remark;
            this.DateTime = dateTime;
            this.Millilitre = millilitre;
        }
    
        public string Remark { get; private set; }
        public DateTime DateTime { get; private set; }
        public Millilitre Millilitre { get; private set; }
    }
