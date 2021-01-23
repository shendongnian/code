    // Enum declaration
	enum AudioSourceNames
	{
		BGM_SOURCE,
		SFX_SOURCE
	}
	
	
	// Called before first update
	public void Start()
	{
		// Dictionary declaration
		Dictionary< int, AudioSource > audioSources;
		
		audioSources = new Dictionary< int, AudioSource > 
		{ 
			( int )BGM_SOURCE, new AudioSource(),
			( int )SFX_SOURCE, new AudioSource()
		};
		
		
		// Accessing the dictionary
		audioSources[ ( int )AudioSourceNames.BGM_SOURCE ].Play();
	}
