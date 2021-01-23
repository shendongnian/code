    private async Task<bool> InitializeAsync()
    {
        try{
            // Initialize this instance.
        }
        catch{
            // Handle issues
            return await Task.FromResult(false);
        }
        return await Task.FromResult(true);
    }
