    public void AttemptAction(Action action)
    {
        try
        {
            action();
        }
        catch (WebException ex)
        {
            ErrorMessages.Add("...");
            _logger.ErrorException("...", ex);
            // Rethrow?
        }
        catch (SoapException ex)
        {
            ErrorMessages.Add("...");
            _logger.ErrorException("...", ex);
            // Rethrow?
        }
    }
