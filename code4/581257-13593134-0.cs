    private void AsyncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (!e.Cancelled && e.Error == null && !IsDisposed && !IsDisposing)
                {
                    if (!_closing)
                    {
                        this.Grid = e.Result as MyGrid;
                        AttachEventHandlersToGrid();
                    }
                    else
                    {
                        (e.Result as MyGrid).Dispose(); // Get rid of grid
                    }
                }
    
                // Get rid of worker
                _worker.DoWork -= DoActionsOnAsyncWork;
                _worker.RunWorkerCompleted -= AsyncWorker_RunWorkerCompleted;
                _worker.Dispose();
                _worker = null;
                if(_closing)
                    this.Dispose(); //call Dispose again, now you know that worker has finished
            }
            protected bool HasBackgroundWorkerFinished()
            {
                if (_worker == null ||
                    !_worker.IsBusy)
                    return true;
                _worker.CancelAsync();
                _closing = true; //this means that worker is busy
                return false;
            }
            protected override void Dispose(bool disposing)
            {
                bool dispose = true;
                if (disposing)
                {
                    dispose = HasBackgroundWorkerFinished();
                    if (dispose)
                    {
                        // Dispose other stuff
                    }
                }
                if(dispose) //don't dispose if worker didn't finish
                    base.Dispose(disposing);
            }
