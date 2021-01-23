    private class MockException : Exception
    {
        public MockException()
        {
            HResult = 0x4005;
        }
    }
