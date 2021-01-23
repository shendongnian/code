    using (F())
    {
        // The instance returned by F IS NOT allowed to be collected here
        Thread.Sleep(5000);
        // The instance returned by F IS NOT allowed to be collected here
    }
    // The instance returned by F IS allowed to be collected here
