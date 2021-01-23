	public List<Section> GetAllSections()
        {
        	var memoryCache = MemoryCache.Default;
            if (!memoryCache.Contains("section"))
            {
                var expiration = DateTimeOffset.UtcNow.AddMinutes(5);
                var sections = context.Sections.ToList();
                memoryCache.Add("section", section, expiration);
            }
           	return memoryCache.Get("section", null);
            
        }
