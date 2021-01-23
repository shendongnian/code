    public class MyLine
    {
        private Line _theBoringOriginal; // composition: "has-a" (vs inheritance "is-a")
        public MyLine(Line line)
        {
            _theBoringOriginal = line;
        }
        public foo SomeProperty { get; set; }
    }
