    void MeasurementWorker(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        if (worker.CancellationPending)
        {
             if (_lastMeasurement != null)
             {
                 _lastMeasurement.Stop(); //I am guessing this method is supported.
                 _lastMeasurement = null;
             }
        }
        else
        {
            _lastMeasurement = new Measurement();
            _lastMeasurement.Execute();
        }
    }
