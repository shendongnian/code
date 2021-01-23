    public class ViewModel
    {
        public ObservableCollection<string> Items {get;set;}
    
        public ViewModel()
        {
            Items = new ObservablecCollection<string>();
            Items.Add("String1");
            Items.Add("String2");
            Items.Add("String3");
        }
    }
