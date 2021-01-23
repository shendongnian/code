    private interface IBase1
    {
        int Percentage { get; set; }
    }
    private interface IBase2
    {
        int Percentage { get; set; }
    }
    private interface IAllYourBase : IBase1, IBase2
    {
       new int Percentage { get; set; }
    }
    private class AllYourBase : IAllYourBase
    {
        private int _percentage;
        public int Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }
    }
    private void Foo()
    {
        IAllYourBase iayb = new AllYourBase();
        int percentage = iayb.Percentage; //OK
    } 
