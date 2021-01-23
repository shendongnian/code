    catch (Exception ex)
    {
        string message = ex.Message.Substring(0, ex.Message.IndexOf("Actual:"));
        LogMessage(message);
        Asset.Fail(ex.Message);
    }
