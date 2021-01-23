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
		if (info.ProductNumber != null && info.ProductNumber.ToLower().Trim().Length > 0
			    &&
			    info.CancelledByReliantSyncAB01 != null && info.CancelledByReliantSyncAB01.Value == true)
		{
			return true;
		}
		
		if ((info.PartnerContract == null || info.PartnerContract.Trim().Length == 0)
			&&
			(info.ProductNumber == null || info.ProductNumber.Trim().Length == 0))
		{
			return true;
		}
		
		return false;
	}
