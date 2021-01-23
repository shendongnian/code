    catch (Exception ex)
    {
        var fault = ex as System.ServiceModel.FaultException<DefaultFaultContract>;
        if(fault != null)
        {
            ExcelRecorder(fault.Detail.ErrorCode, fault.Detail.Message,
                fault.Message, row);
        }
        // TODO: common error handling steps
    }
