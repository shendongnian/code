	public static IList<ClientEntity> FilterNoNeedSendBackToClients(IList<ClientEntity> src)
	{
		if (src == null)
		    return null;
		
		for (int i = src.Count - 1; i >= 0; i--)
		{
			if (ShouldClientNotSendBack(src[i]))
				src.RemoveAt(i);
		}
		
		return src;
	}
	
	private static bool ShouldClientNotSendBack(ClientEntity info)
	{
		if (!String.IsNullOrWhiteSpace(info.ProductNumber) && info.CancelledByReliantSyncAB01 == true)
		{
			return true;
		}
		
		if (!String.IsNullOrWhiteSpace(info.PartnerContract))
		{
			return true;
		}
		
		return false;
	}
