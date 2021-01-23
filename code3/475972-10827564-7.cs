    private void PlayWithRx()
    {
        // we init the observavble with the lines read from the file
        var source = this.ReadLinesFromFile("some file").ToObservable(Scheduler.TaskPool);
        source.ObserveOn(this).Subscribe(x =>
        {
            // for each line read, we update the UI
            this.DisplayResults(x, Color.Red, "Read");
            // for each line read, we subscribe the line to the ProcessLine method
            var process = Observable.Start(() => this.ProcessLine(x.Line), Scheduler.TaskPool)
                .ObserveOn(this).Subscribe(c =>
                {
                    // for each line processed, we update the UI
                    this.DisplayResults(c, Color.Blue, "Processed");
                    // for each line processed we subscribe to the final process the UpdateResultToDatabase method
                    // finally, we update the UI when the line processed has been saved to the database
                    var persist = Observable.Start(() => this.UpdateResultToDatabase(c.Line), Scheduler.TaskPool)
                        .ObserveOn(this).Subscribe(z => this.DisplayResults(z, Color.Black, "Saved"));
                });
        });
    }
