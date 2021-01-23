<!-- -->
    using System.Windows.Controls;
    private Page _slideFrame;
    // Property
    public Page SlideFrame
    {
        get { return _slideFrame; }
        set
        {
            _slideFrame = value;
            NotifyPropertyChanged("SlideFrame");
        }
    }
