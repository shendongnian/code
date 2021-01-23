    public class TestFile1
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(DemoPropertyDataSource))]
        public void SampleTest1(int number, bool expectedResult)
        {
            var sut = new CheckThisNumber(1);
            var result = sut.CheckIfEqual(number);
            Assert.Equal(result, expectedResult);
        }
    }
