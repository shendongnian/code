    public class StringTests1
    {
        [Theory,
        InlineData("goodnight moon"),
        InlineData("hello world")]
        public void Contains(string input)
        {
            NamerFactory.AdditionalInformation = input;  // <- important
            Approvals.Verify(transform(input));
        }
    } 
