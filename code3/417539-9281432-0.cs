    #if DEBUG
    
        [Test]
        public void DebugOnlyTest()
        {
            ...
        }
    
    #else
    
        [Test]
        public void ReleaseOnlyTest()
        {
            ...
        }
    
    #endif
    
        [Test]
        public void NormalTest()
        {
            ...
        }
