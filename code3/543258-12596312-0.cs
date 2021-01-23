    catch (System.ServiceModel.FaultException<DefaultFaultContract> ex)
    {
        ExcelRecorder(ex.Detail.ErrorCode, ex.Detail.Message, ex.Message, row);
    }
    catch (Exception ex)
    {
        // TODO: simpler error handler
    }
