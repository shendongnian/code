    async Task Test1()
    {
        int a = 0; // Will be called on the called thread.
        int b = await this.GetValueAsync(); // Will be called on background thread 
        int c = 1; // Method execution will come back to the called thread again on this line.
        int d = await this.GetValueAsync(); // Going again to background thread
    }
