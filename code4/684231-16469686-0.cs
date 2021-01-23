    public class IndexViewModel
	{
		public string Search { get; set; }
		public IPagedList<MembershipUser> Users { get; set; }
		public IEnumerable<string> Roles { get; set; }
		public bool IsRolesEnabled { get; set; }
        public IDictionary<string,string> Tags { get; set; }
	}
