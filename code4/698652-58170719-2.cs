    public class ATest
    {
        [Theory, AutoNSubstituteData]
        public void ATestMethod(AInterface aInterface)
        {
            var sut = new Fixture()
                .For<AClass>()
                .Set("value1").To(aInterface)
                .Set("value2").ToEnumerableOf(22, 33)
                .Create();
            Assert.True(ReferenceEquals(aInterface, sut.Value1));
            Assert.Equal(2, sut.Value2.Count());
            Assert.Equal(22, sut.Value2.ElementAt(0));
            Assert.Equal(33, sut.Value2.ElementAt(1));
        }
    }
