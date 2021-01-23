	public static IList<ClientEntity> FilterNoNeedSendBackToClients(IList<ClientEntity> src)
	{
		if (src == null)
		    return null;
		
		for (int i = src.Count - 1; i >= 0; i--)
		{
			ClientEntity info = src[i];
			if (info.ProductNumber != null && info.ProductNumber.ToLower().Trim().Length > 0
			    &&
			    info.CancelledByReliantSyncAB01 != null && info.CancelledByReliantSyncAB01.Value == true)
			{
				src.RemoveAt(i);
			}
			else if ((info.PartnerContract == null || info.PartnerContract.Trim().Length == 0)
				&&
				(info.ProductNumber == null || info.ProductNumber.Trim().Length == 0))
			{
				src.RemoveAt(i);
			}
		}
		
		return src;
	}
