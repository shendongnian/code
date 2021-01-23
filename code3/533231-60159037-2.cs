    public sealed class Email
	{
		public string From { get; set; }
		/// <summary>
		/// Email address(es) to (can be settable separated list, default: ;)
		/// </summary>
		public string To { get; set; }
        //.....
		/// <summary>
		/// Separator char for multiple email addresses
		/// </summary>
		public char EmailAddressSeparator { get; set; }
		public Email()
		{
			EmailAddressSeparator = ';';
		}
    }
