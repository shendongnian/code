    // The following two scroll changed methods will not be called recursively and lead to dead loop.
    // When scrolling _masterSV, OnMasterScrollChanged will be called, so _headerSV also scrolled
    // to the same offset. Then, OnHeaderScrollChanged be called, and try to scroll _masterSV, but
    // it's already scrolled to that offset, so OnMasterScrollChanged will not be called.
 
    // When master scroll viewer changed its offset, change header scroll viewer accordingly
    private void OnMasterScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (_headerSV != null && _mainSV == e.OriginalSource)
        {
            _headerSV.ScrollToHorizontalOffset(e.HorizontalOffset);
        }
    }
 
    // When header scroll viewer changed its offset, change master scroll viewer accordingly
    private void OnHeaderScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (_mainSV != null && _headerSV == e.OriginalSource)
        {
            _mainSV.ScrollToHorizontalOffset(e.HorizontalOffset);
        }
    }
