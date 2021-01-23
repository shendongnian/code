    public interface ITest
    { Int32 GetNumber(); }
    static class Program
    {
        static void Main()
        {
            var a = new Mock<ITest>();
            var f = 0;
            a.Setup(x => x.GetNumber()).Returns(() => f++ == 0 ? 0 : 1);
            Debug.Assert(a.Object.GetNumber() == 0);
            for (var i = 0; i<100; i++)
                Debug.Assert(a.Object.GetNumber() == 1);
        }
    }
