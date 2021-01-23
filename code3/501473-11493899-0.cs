    public class MyBrackets : naturalCalc.Enginee.Reference
    {
        public MyBrackets(bool opener)
        {
            this.Opener = opener;
        }
    
        public bool Opener 
        {
            private set { this.Opener = value; }
            get { return this.Opener; } 
        }
    }
