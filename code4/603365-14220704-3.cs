     public TopBarControl:UserControl
     {
        public Frame Frame {get;set;} // To be set in either OnNavigatedTo, or in Constructor. 
        public TopBarControl(Frame frame)
        {
            this.Frame = frame;
        }         
     }
