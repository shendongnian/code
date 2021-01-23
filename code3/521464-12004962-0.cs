    [Test]
    public void myTest
    {
        try
        {
           // Hier you call your methode GetBookInfo(null)
           Assert.True(false);
        }
        Catch (NullReferenceException e)
        {
            Assert.True(true);
        }    
    } 
