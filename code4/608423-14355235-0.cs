    public class NoFocusCueButton : Button
    {
        public NoFocusCueButton() : base()
        {
            InitializeComponent();
    
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override bool ShowFocusCues
        {
            get
            {
    	       return false;
            }
        }
    }
