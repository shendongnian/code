    public class InsulineInjection
    {
        public InsulineInjection(Millilitre millilitre, DateTime dateTime, string remark)
        {
            this.Remark = remark;
            this.DateTime = dateTime;
            _millilitre = millilitre;
        }
    
        public string Remark { get; set; }
        public DateTime DateTime { get; set; }
        public Millilitre Millilitre { get { return _millilitre; } }
    }
