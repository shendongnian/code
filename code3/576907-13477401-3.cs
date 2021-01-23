    public virtual void NewReportSetup(params)
    {
        ...
        parameters.Add( new Microsoft.Reporting.WinForms.ReportParameter("paramBatch", batch));
        ...
        FinalizeParameters(parameters, paramsThatAreImplSpecific);
    }
    
    protected abstract void FinalizeParameters(List, paramsThatAreImplSpecific);
