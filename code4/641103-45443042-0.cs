    	[NotMapped]
		public IEnumerable<double> Data
		{
			get
			{
				var tab = InternalData.Split(',');
				return tab.Select(double.Parse).AsEnumerable();
			}
			set { InternalData = string.Join(",", value); }
		}
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string InternalData { get; set; }
