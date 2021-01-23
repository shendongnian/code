    public string GetResultSafely()
    {
        try {
            // Possibly failing
            return ReadStringFromExternalResource();
        } catch() {
           return String.Empty;
        }
    }
