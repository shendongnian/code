    public class A
    {
        int P1 { get; set; }
        int P2 { get; set; }
    }
    
    [TestMethod()]
    public void ATest()
    {
        A expected = new A() {42, 99};
        A actual = SomeMethodThatReturnsAnA();
        Assert.AreEqual(expected, actual);
    }
