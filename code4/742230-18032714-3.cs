    // find needed elements and hook up events
    private void RenewEvents()
    {
        ScrollViewer oldHeaderSV = _headerSV;
        _headerSV = Parent as ScrollViewer;
        if (oldHeaderSV != _headerSV)
        {
            if (oldHeaderSV != null)
            {
                oldHeaderSV.ScrollChanged -= new ScrollChangedEventHandler(OnHeaderScrollChanged);
            }
            if (_headerSV != null)
            {
                _headerSV.ScrollChanged += new ScrollChangedEventHandler(OnHeaderScrollChanged);
            }
        }
  
        ScrollViewer oldSV = _mainSV; // backup the old value
        _mainSV = TemplatedParent as ScrollViewer;
  
        if (oldSV != _mainSV)
        {
            if (oldSV != null)
            {
                oldSV.ScrollChanged -= new ScrollChangedEventHandler(OnMasterScrollChanged);
            }
 
            if (_mainSV != null)
            {
                _mainSV.ScrollChanged += new ScrollChangedEventHandler(OnMasterScrollChanged);
            }
        }
        ...
