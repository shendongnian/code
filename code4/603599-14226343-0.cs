	[XmlAttribute("Id")]
	public virtual long Id { get; set; }
	[XmlAttribute("Name")]
	public virtual string Name { get; set; }
	protected internal virtual IList<EmailBranch> EmailBranches { get; set; }
	//private List<EmailBranch> _test = new List<EmailBranch>();
	//[XmlArray("EmailBranches")]
	//[XmlArrayItem("EmailBranch", typeof(EmailBranch))]
	//public virtual List<EmailBranch> EmailBranchesProxy {
	//    get { return EmailBranches != null ? EmailBranches.ToList() : null; }
	//    set { EmailBranches = value; }
	//}
	[XmlArray("EmailBranches")]
	[XmlArrayItem("EmailBranch", typeof(EmailBranch))]
	public virtual List<EmailBranch> EmailBranchesProxy
	{
		get 
		{
			var proxy = EmailBranches as List<EmailBranch>;
			if (proxy == null && EmailBranches != null)
			{
				proxy = EmailBranches.ToList();
			}
			return proxy;
		}
		set { EmailBranches = value; }
	}
	public EmailCategory()
	{
		EmailBranches = new List<EmailBranch>();
	}
