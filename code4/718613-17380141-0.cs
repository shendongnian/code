    public async Task<UserProfile> GetProfileAsync(Guid userId)
    {
        // First check the cache
        UserProfile cached;
        if (profileCache.TryGetValue(userId, out cached))
        {
            return cached;
        }
        // Nope, we'll have to ask a web service to load it...
        UserProfile profile = await webService.FetchProfileAsync(userId);
        profileCache[userId] = profile;
        return profile;
    }
