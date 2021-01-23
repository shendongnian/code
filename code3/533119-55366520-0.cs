    public interface INullable
    {
        int Method(Guid? guid);
    }
    var mock = new Mock<INullable>();
    mock.Setup(m => m.Method(It.IsAny<Guid?>())).Returns(6);
    int a = mock.Object.Method(null); // a is 6
