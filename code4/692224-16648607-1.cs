	static public T Try<T>(string webMessage, string soapMessage, Func<T> func)
    {
		try
		{
			return func();
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
