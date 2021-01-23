    // Summary:
    //     Specifies how a bitmap image takes advantage of memory caching.
    public enum BitmapCacheOption
    {
    	// Summary:
    	//     Creates a memory store for requested data only. The first request loads the
    	//     image directly; subsequent requests are filled from the cache.
    	OnDemand = 0,
    	//
    	// Summary:
    	//     Caches the entire image into memory. This is the default value.
    	Default = 0,
    	//
    	// Summary:
    	//     Caches the entire image into memory at load time. All requests for image
    	//     data are filled from the memory store.
    	OnLoad = 1,
    	//
    	// Summary:
    	//     Do not create a memory store. All requests for the image are filled directly
    	//     by the image file.
    	None = 2,
    }
