    void MeasurementWorker(object sender, DoWorkEventArgs e)
    {
        _lastMeasurement = new Measurement();
        _lastMeasurement.Execute();
        BackgroundWorker worker = sender as BackgroundWorker;
        while (true)
        {
            if (worker.CancellationPending)
            {
                _lastMeasurement.Stop(); //I am guessing this method is supported.
                _lastMeasurement = null;
                break;
            }
            Thread.Sleep(0);
        }
    }
