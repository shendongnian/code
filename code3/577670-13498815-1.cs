public abstract class MyTests
{
    [Test]
    public void TestOne()
    {
        ...
    }
    [Test]
    public void TestTwo()
    {
        ...
    }
}
[TestFixture]
public class FirstSetup : MyTests
{
    [Setup]
    public void Setup()
    {
        ...
    }
}
[TestFixture]
public class SecondSetup : MyTests
{
    [Setup]
    public void Setup()
    {
        ...
    }
}
