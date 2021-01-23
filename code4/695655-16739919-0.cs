    namespace Blood
    {
        public struct BloodComponents
        {
            public string name;
            public double salt, RBC;
        }
        public struct BloodWork
        {
            public double drugConc, dilution, volume;
            public BloodComponents vein, artery;
            public void SetParameters()
            {
            }
            public void BloodProteintParams()
            {
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var work=new BloodWork()
                {
                    drugConc=0.1,
                    dilution=0.2,
                    volume=0.3,
                    vein=new BloodComponents() { name="A", RBC=0.2, salt=0.6 },
                    artery=new BloodComponents() { name="B", RBC=0.5, salt=0.9 }
                };
            }
        }
    }
