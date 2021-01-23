    public class PhoneAreaAttributeTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData(" ", true)]
        [InlineData(null, true)]
        public void IsValid_WithCorrectInput_ReturnsTrue(
            object value, bool expected)
        {
            // Setup
            var phoneAreaAttribute = CreatePhoneAreaAttribute();
            // Exercise
            var actual = phoneAreaAttribute.IsValid(value);
            // Verify
            actual.Should().Be(expected, "{0} should be valid input", value);
            // Teardown            
        }
        [Theory]
        [InlineData("012", false)]
        [InlineData("A12", false)]
        [InlineData("1", false)]
        [InlineData("12345", false)]
        public void IsValid_WithIncorrectInput_ReturnsFalse(
            object value, bool expected)
        {
            // Setup
            var phoneAreaAttribute = CreatePhoneAreaAttribute();
            // Exercise
            var actual = phoneAreaAttribute.IsValid(value);
            
            // Verify
            actual.Should().Be(expected, "{0} should be invalid input", value);
            
            // Teardown      
        }
        [Fact]
        public void IsValid_UsingNonStringInput_ThrowsExcpetion()
        {
            // Setup
            var phoneAreaAttribute = CreatePhoneAreaAttribute();
            const int input = 123;
            // Exercise
            // Verify
            Assert.Throws<InvalidCastException>(
                () => phoneAreaAttribute.IsValid(input));
            // Teardown     
        }
   
        // Simple factory method so that if we change the
        // constructor, we don't have to change all our 
        // tests reliant on this object.
        public PhoneAreaAttribute CreatePhoneAreaAttribute()
        {
            return new PhoneAreaAttribute();
        }
    }
