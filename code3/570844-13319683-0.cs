    public class C2 : C1, I2 
    {
        string I2.Property1 
        {
            get { return base.Property1; } 
            set { base.Property1 = value; }
        }
        public string Property2 {get; set;}
        public override void OnEvent() {base.OnEvent(); /*populate property2...*/}
    }
