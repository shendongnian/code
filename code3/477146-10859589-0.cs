    public class CombinationsGenerator<T>
    {
        public readonly ReadOnlyCollection<T> AllElements;
        public readonly int CombinationSize;
        private int _currentCombination;
        public static IEnumerable<IEnumerable<T>> GetAll(int combinationSize,
                                                         params T[] allElements)
        {
            return allElements.Select((t, x) =>
                allElements.Where((item, index) => (x & (1 << index)) != 0));
        }
        public CombinationsGenerator(int combinationSize,
                                     IEnumerable<T> allElements)
            : this(combinationSize, allElements.ToArray())
        {
        }
        public CombinationsGenerator(int combinationSize,
                                     params T[] allElements)
        {
            this.CombinationSize = combinationSize;
            this.AllElements = new ReadOnlyCollection<T>(allElements);
            this.Reset();
        }
        public IEnumerable<T> Next()
        {
            if (this._currentCombination == int.MaxValue)
            {
                return null;
            }
            this._currentCombination++;
            return this.AllElements.Where((item, index) =>
                (this._currentCombination & (1 << index)) != 0);
        }
        public void Reset()
        {
            this._currentCombination = -1;
        }
    }
