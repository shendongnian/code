    public void RanToCompletion(Task task)
        {
            if (_frmProgress.Dispatcher.CheckAccess())
                _frmProgress.Close();
            else
                _frmProgress.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(_frmProgress.Close));
        }
