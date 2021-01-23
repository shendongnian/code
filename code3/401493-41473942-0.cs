    [SuppressMessage("ReSharper", "All")]
    private void MethodWithMultipleIssues()
    {
        TestClass instance = null;
        // You would get an "Expression is always true" message
        if (instance == null)
        {
            Debug.WriteLine("Handle null");
        }
        else
        {
            // You would get an "Code is unreachable" message
            Debug.WriteLine("Handle instance");
        }
    }
