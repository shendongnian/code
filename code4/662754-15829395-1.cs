    public class Class1
    {
        private int pam1;
        public Class1(){}
        private void ChancePam1(int newValue)
        {
            UpdatePam1(newValue);
            pam1 = newValue;
        }
        public int Pam1
        {
            set { ChancePam1(value); }
            get { return this.pam1; }
        }
    }
