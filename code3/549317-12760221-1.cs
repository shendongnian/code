    public abstract class AbstractClass
    {
        protected AbstractClass(int i)
        {
            this.Prop = i;
        }
        public int Prop { get; set; }
    }
    // ...
        [Fact]
        public void Test()
        {
            var ac = new Mock<AbstractClass>(MockBehavior.Loose, 10);
            Assert.Equal(ac.Object.Prop, 10);
        }
