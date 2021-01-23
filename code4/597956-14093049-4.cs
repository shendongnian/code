    public class RetValDynamicVisitorTests
    {
        private readonly RetValDynamicVisitor _sut = new RetValDynamicVisitor();
        [Fact]
        public void VisitTest()
        {
            FooBase fooBase = _sut.Visit(new FooBase());
            FooBase barAsFooBase = _sut.Visit(new Bar() as FooBase);
            Bar bar = _sut.Visit(new Bar());
            Assert.Equal(RetValDynamicVisitor.FooVal, fooBase.RetVal);
            Assert.Equal(RetValDynamicVisitor.BarVal, barAsFooBase.RetVal);
            Assert.Equal(RetValDynamicVisitor.BarVal, bar.RetVal);
        }
    }
