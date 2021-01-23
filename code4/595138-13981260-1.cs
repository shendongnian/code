    public class DataBagDecorator : IDataBag
    {
        private IDataBag _dataBag;
    
        public DataBagDecorator(IDataBag dataBag)
        {
            _dataBag = dataBag;
        }
    
        public virtual string UserControl
        {
            get { return _dataBag.UserControl; }
            set { _dataBag.UserControl = value; }
        }
    
        // other members
    }
