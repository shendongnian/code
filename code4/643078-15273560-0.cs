    [STAThread]
    private void OnRepetitionComplete(Evolve.Core.Simulation.RepetitionResult Result)
    {
        //Convert the data series to something usable for the chart
        EnumerableDataSource<DataPoint> seriesToAdd = new EnumerableDataSource<DataPoint>(_obCurrentRepetitionDataSeries);
        //Translate the data point properties in to X&Y coords on the graph
        seriesToAdd.SetXYMapping(DP => new System.Windows.Point(DP.Step, DP.Number));
        //Get the line colour and add the line to the chart
        System.Windows.Media.Color lineColor = GetLineColor(Result.ReasonForCompletion);
        lock (chartLockObject)
        {
            lock (lineLockObject)
            {
                _obChart.Dispatcher.Invoke(new Action(() =>
                {
                    _obChart.AddLineGraph(seriesToAdd, lineColor, 0.5d);
                }));
                //Renew the data series
                _obCurrentRepetitionDataSeries = new DataSeries();
            }
        }
    }
    private void OnStep(int StepNumber, int HealthyNodes, int MutantNodes)
    {
        //Make sure there's a data series to add to
        if (_obCurrentRepetitionDataSeries == null)
        {
            _obCurrentRepetitionDataSeries = new DataSeries();
        }
        lock (lineLockObject)
        {
            //Add the step to the series
            _obCurrentRepetitionDataSeries.Add(new DataPoint() { Number = MutantNodes, Step = StepNumber });
        }
    }
