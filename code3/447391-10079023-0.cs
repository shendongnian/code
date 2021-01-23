    public class LogicClass
    {
        private String _myText;
    
        public event EventHandler MyTextChanged;
    
        public String MyText
        {
            get{return _myText;}
            set
            {
                _myText = value; 
                var handler = MyTextChanged;
                if(handler != null){ MyTextChanged(this, EventArgs.Empty); }
            }
        }
        ...
    }
    
    public partial class Window1: Window, INotifyPropertyChanged
    {
        private LogicClass _logic;
    
        public Window1()
        {
           _logic = ... initialised;
           _logic.MyTextChanged += (s,e) => RaisePropertyChanged("LogicText");
        }
    
       
        public String LogicText
        {
            get{return _logic.MyText;}
        }
        ...
    }
