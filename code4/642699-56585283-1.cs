     using Xunit;
    
        namespace Tests
    {
        public class MaskingTest
        {
            [Theory]
            [InlineData("ThisIsATest", 4, 'x', "xxxxxxxTest")]
            [InlineData("Test", 4, null, "Test")]
            [InlineData("ThisIsATest", 4, '*', "*******Test")]
            [InlineData("Test", 16, 'x', "Test")]
            [InlineData("Test", 0, 'y', "yyyy")]
            public void Testing_Masking(string input, int charToDisplay, char maskingChar, string expected)
            {
                //Act
                string actual = input.MaskAllButLast(charToDisplay, maskingChar);
    
                //Assert
                Assert.Equal(expected, actual);
            }
        }
    }
 
