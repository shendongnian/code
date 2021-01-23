           try
            {
                Task reportTask = Task.Factory.StartNew(
                    () =>
                    {
                        Report report = new Report(this._manager);
                        report.ExporterPDF();
                    }
                    , CancellationToken.None
                    , TaskCreationOptions.None
                    , TaskScheduler.FromCurrentSynchronizationContext()
                    );
    
                reportTask.Wait();
            }
            catch (AggregateException ex)
            {
                foreach(var exception in ex.InnerExceptions)
                {
                    throw ex.InnerException;
                }
            }
