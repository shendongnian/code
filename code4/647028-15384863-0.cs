	[Table("agency")]
	class Agency
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int my_id { get; set; }
		public string name { get; set; }
	}
