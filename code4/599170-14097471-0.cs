    [MaxLength(256)]
	public string EmailAddress 
	{ 
		get
		{
			return this.Emails.First().ToString();
		} 
		set
		{
			if (Emails == null)
			{
				Emails = new Collection<Email>(); 
			}
			Emails.Items.Insert(0);
		}
	}
