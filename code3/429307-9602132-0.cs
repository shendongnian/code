    public class Bill
    {
        public string Name {get;set;}
        public double Value {get;set;}
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Bill> earnings;
        public ObservableCollection<Bill> Earnings
        {
            get {return earnings;}
            set
            {
                if (earnings != value)
                {
                    earnings = value;
                    if (earnings != null)
                    {
                        earnings.CollectionChanged += (s, e) =>
                        {
                            NotifyPropertyChanged("Breakdown");
                        }
                    }
                }
            }
        }
        //Outgoins the same as Earnings
        public double Breakdown
        {        
            get
            {
                Sum = 0;
                foreach (Bill in Earnings)
                {
                    Sum += Bill.Value;
                }
                foreach (Bill in Outgoins)
                {
                    Sum -= Bill.Value;
                }
                return Sum;
            }
        }
    }
