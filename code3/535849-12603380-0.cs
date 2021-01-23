    IntPtr token = WindowsIdentity.GetCurrent().Token;
	Parallel.ForEach( Enumerable.Range( 1, 100 ), ( test ) =>
	{
		using ( WindowsIdentity.Impersonate( token ) )
		{
		      Console.WriteLine( WindowsIdentity.GetCurrent( false ).Name );
		}
	} );
