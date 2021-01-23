    public class IterationExample
    {
        private readonly Dictionary<bool, Action> dictionary;
        public IterationExample()
        {
            dictionary = new Dictionary<bool, Action> { { true, CollectionOneIterator }, { false, CollectionTwoIterator } };
        }
        public void PublicMethod()
        {
            dictionary[condition]();
        }
        private void CollectionOneIterator()
        {
            foreach (var loopVariable in Type1Collection)
            {
                //Your code here
            }
        }
        private void CollectionTwoIterator()
        {
            foreach (var loopVariable in Type2Collection)
            {
                //Your code here
            }
        }
    }
