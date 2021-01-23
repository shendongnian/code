	private Dictionary<Type, ObjectQuery> m_ObjectSets;
	private Dictionary<Type, ObjectQuery> ObjectSets
	{
		get
		{
			if( m_ObjectSets == null )
			{
				m_ObjectSets = new Dictionary<Type, ObjectQuery>( );
				m_ObjectSets[ typeof( YourTypeA ) ] = YourObjectSetA;
				m_ObjectSets[ typeof( YourTypeB ) ] = YourObjectSetB;
				...
			}
			return m_ObjectSets;
		}
	}
