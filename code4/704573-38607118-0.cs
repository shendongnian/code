    public interface IMyObj
    {
        string ToString();
    }
    public class MyObj : IMyObj
    ...
    var iMoq = new Mock<IMyObj>();
    iMoq.setup(o => o.ToString()).Returns(r);
    myList.Add(iMoq.Object);
    myList.Add(iMoq.Object);
