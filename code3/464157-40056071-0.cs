    public class Combination<T>
    {
        private IEnumerable<T> list { get; set; }
        private int length;
        private List<IEnumerable<T>> _allCombination;
        public Combination(IEnumerable<T> _list)
        {
            list = _list;
            length = _list.Count();
            _allCombination = new List<IEnumerable<T>>();
        }
        public IEnumerable<IEnumerable<T>> AllCombinations
        {
            get
            {
                GenerateCombination(default(int), Enumerable.Empty<T>());
                return _allCombination;
            }
        }
        private void GenerateCombination(int position, IEnumerable<T> previousCombination)
        {
            for (int i = position; i < length; i++)
            {
                var currentCombination = new List<T>();
                currentCombination.AddRange(previousCombination);
                currentCombination.Add(list.ElementAt(i));
                _allCombination.Add(currentCombination);
                GenerateCombination(i + 1, currentCombination);
            }
        }
    }
