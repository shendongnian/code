    [Test]
    public int Check ([Range(0,100,1)] int tries)
    {
       for (int i = 0; i < tries; i++)
       {
           if (i % 2 == 1) Assert.Fail("failed on :" + i);
       }
    }
