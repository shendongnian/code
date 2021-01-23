    public class LimitTest
    {
        [Fact]
        public void Test()
        {
            int number = 3;
    
            Assert.Equal(3, number.Limit(0, 4));
            Assert.Equal(4, number.Limit(4, 6));
            Assert.Equal(1, number.Limit(0, 1));
    
        }
    }
