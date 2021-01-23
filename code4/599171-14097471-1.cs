    [MaxLength(256)]
	public string EmailAddress 
	{ 
		get
		{
			return this.Emails.DefaultIfEmpty(new EMail()).First().EmailAddress;
		} 
		set
		{
			if (Emails == null)
			{
				Emails = new Collection<Email>(); 
			}
			Emails.Items.Insert(0, new EMail {EmailAddress = value}); 
		}
	}
