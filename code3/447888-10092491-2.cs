	readonly IOGF<C> _ogf;
	public D( IOGF<C> ogf )
	{
		_ogf = ogf;
	}
	public IOGF<C> Ogf
	{
		get { return _ogf; }
	}
}
