    public eDisplayPages Window1Page
    {
        get { return _window1page; }
        set
        {
            if (_window1page == value)
                return;
            if ((value.Equals(_window2page)) && (value != eDisplayPages.NoDashPage))
            {
                //Can't have them both selecting the same page
                _window1page = eDisplayPages.NoDashPage;
            }
            else
            {
                _window1page = value;
            }
            //TODO: add some change notification here
        }
    }
