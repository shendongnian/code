    public ProgressBarUpdate(ProgressBar pb, int total)
    {
        _pb = pb;
        _total = total;
        _delta = _pb.MaxValue/((double)total);  /make sure you do not truncate delta
        _current = 0;
        _pb.Visibility = Visibility.Visible;
    }
    public void Dispose()
    {
        _pb.Visibility = Visibility.Collapsed;
        _current = 0;
    }
    public void UpdateProgress()
    {
        _pb.Value = (int)( _delta * (++_current)); //update after the increment
    }
