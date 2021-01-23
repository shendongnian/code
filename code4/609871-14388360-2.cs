    internal class TempratureInfo
    {
        public string Name { get; set; }
        public double Temprature { get; set; }
        public override string ToString()
        {
            return string.Format("Temprature in {0} is currently {1}", Name, Temprature);
        }
    }
