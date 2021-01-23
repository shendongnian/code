	public MyClass() : base("Mono.Data.Sqlite", 
        "Mono.Data.Sqlite.SqliteConnection", "Mono.Data.Sqlite.SqliteCommand")
	{
	public override bool UseNamedPrefixInSql
	{
		get { return true; }
	}
	public override bool UseNamedPrefixInParameter
	{
		get { return true; }
	}
	public override string NamedPrefix
	{
		get { return "@"; }
	}
