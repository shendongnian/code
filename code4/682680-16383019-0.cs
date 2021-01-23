	private void AddAliasesThatContainsCtid(string ctid, IList<MamConfiguration_V1> results)
	{
	...
		results.AddRange(mMaMDBEntities.MamConfigurationToCTIDs_V1
			.Where(item => item.CTID == aliasId)
			Select(item => item.MamConfiguration_V1));
	   }
	}
