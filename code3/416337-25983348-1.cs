    public interface ICoOrd
    {
        int X { get; set; }
        int Y { get; set; }
    }
    public class Sample
    {
        public void Test()
        {
            var aCord = new Mock<ICoOrd>();
            aCord.SetupGet(c => c.X).Returns(44);
            aCord.SetupGet(c => c.Y).Returns(55);
            var a = aCord.Object;
        }
    }
