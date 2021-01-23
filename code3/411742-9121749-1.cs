    public class Bar
    {
        public virtual void SomeMethod(string param)
        {
            //whatever
        }
    }
    public interface IBarRepository
    {
        List<Bar> GetBarsFromStore();
    }
    public class FooService
    {
        private readonly IBarRepository _barRepository;
        public FooService(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }
        public List<Bar> GetBars()
        {
            var bars = _barRepository.GetBarsFromStore();
            foreach (var bar in bars)
            {
                bar.SomeMethod("someValue");
            }
            return bars;
        }
    }
    [TestMethod]
    public void Verify_All_Bars_Called()
    {
        var myBarStub = new Mock<Bar>();
        var mySecondBarStub = new Mock<Bar>();
        var myBarList = new List<Bar>() { myBarStub.Object, mySecondBarStub.Object };
        var myStub = new Mock<IBarRepository>();
        myStub.Setup(repos => repos.GetBarsFromStore()).Returns(myBarList);
        var myService = new FooService(myStub.Object);
        myService.GetBars();
        myBarStub.Verify(bar => bar.SomeMethod(It.IsAny<string>()), Times.Once());
        mySecondBarStub.Verify(bar => bar.SomeMethod(It.IsAny<string>()), Times.Once());
    }
