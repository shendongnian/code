    public class FsFileGroupFileBuilder
    {
        public string FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public string ThirdProperty { get; set; }
        public string FourthProperty { get; set; }
        public string FifthProperty { get; set; }
        public FsFileGroupFile Build()
        {
            return new FsFileGroupFile(FirstProperty, SecondProperty, ThirdProperty,
                FourthProperty, FifthProperty);
        }
    }
