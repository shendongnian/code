    static public void Try(string webMessage, string soapMessage, Action action)
    {
		try
		{
			action();
		}
		catch (WebException ex)
		{
			ErrorMessages.Add(webMessage);
			_logger.ErrorException(webMessage, ex);
		}
		catch (SoapException ex)
		{
		   ErrorMessages.Add(soapMessage);
			_logger.ErrorException(soapMessage, ex);
		}
	}
