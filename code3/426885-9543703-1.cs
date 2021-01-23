    public void SomeMethod()
		{
			Name = "fred";
		}
		private string name=null;
		public string Name
		{
			get
			{
				name;
			}
			set
			{
				Amethodthatchecksthestack();
				name = value;
			}
		}
