	public IList<Account> GetBrokerAccounts(int brokerId)
	{
		return session.QueryOver<Account>()
		.Where(x => x.Broker == session.Load(brokerId)).List();
	}
