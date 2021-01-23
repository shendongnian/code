    [Test]
    [TestCase( 1, 2, new long[] { 100, 200 }, TestName="Test 1" )]
    [TestCase( 5, 3, new long[] { 300, 500 }, TestName="Test 2" )]
    public void MyClass_MyOtherMethod( long a, long b, long[] bunchOfNumbers )
    {
       Assert.IsTrue( a < b );
    }
