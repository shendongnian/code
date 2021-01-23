	private static object mylock = new object();
	private static List<Recipient> _recipients = new List<Recipient>();
	public static List<Recipient> Recipients
	{
		get
		{
			List<Recipient> result;
			lock (mylock)
			{
				result = _recipients;
			}
			return result;
		}
		set
		{
			lock (mylock)
			{
				_recipients = value;
			}
		}
	}
