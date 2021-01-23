    public int FramesCount
    {
        get { return (string)GetValue(FramesCountProperty ); }
        set 
        { 
            SetValue(FramesCountProperty , value); 
            if (ImageFileMask != null) ReloadFrames();
        }
    }
