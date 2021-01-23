    public class CalculationViewModel
    {
        public event Action ResultChanged;
        private string _result = string.Empty;
        public string Result
        {
            get { return _result; }
            set { _result = value; Notify(); }
        }
        private void Notify()
        {
            if (ResultChanged!= null)
            {
                ResultChanged();
            }
        }
    }
