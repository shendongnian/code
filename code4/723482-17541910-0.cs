    public class checkClass 
    {
        static ObservableCollection<Subject> _lstSubSelectedItems = new ObservableCollection<Subject>();
        static checkClass chkclss;
        public static checkClass GetInstance()
        {
            if (chkclss == null)
            {
                chkclss =  new checkClass();
            }
            return chkclss;
        }
        public ObservableCollection<Subject> lstSubSelectedItems
        {
            get
            {
                return _lstSubSelectedItems;
            }
            set
            {
                _lstSubSelectedItems = value;
            }
            
        }
    }
