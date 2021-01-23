    private void ReportStatus(Worker worker, Status status, WorkResult result,System.ComponentModel.DoWorkEventArgs arg)
    {
        var proxy = new PreparationServiceProxy(new NetTcpBinding(), new EndpointAddress(PreparationEngineState.ServiceAddress));
        try
        {
            proxy.ReportStatus(worker, status, result);
            proxy.Close();
        }
        catch (Exception exception)
        {
            arg.Result = worker;
            proxy.Abort();
            throw new WorkerException(worker,exception);
        }
    }
