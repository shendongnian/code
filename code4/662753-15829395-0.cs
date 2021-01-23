    public class Class1
    {
        private int pam1;
        public Class1(){}
        public void ChancePam1(int _NewValue)
        {
            UpdatePam1(_NewValue);
            pam1 = _NewValue;
        }
        public int Pam1
        {
            set { ChancePam1(value); }
            get { return this.pam1; }
        }
    }
