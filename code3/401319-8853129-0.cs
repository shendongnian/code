    try
    {
        something();
    }
    catch (GatewayConnectionFailedException)
    {
        throw;
    }
    catch (GatewayException e)
    {
        _logger.Error(e.Message, e);
    }
