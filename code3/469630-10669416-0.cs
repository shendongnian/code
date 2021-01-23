    public class RangeCollection<TValue>
    {
        private readonly int[] _mins;
        private readonly int[] _maxs;
        private readonly TValue[] _values;
        public RangeCollection(params Tuple<int, int, TValue>[] input)
            : this((IEnumerable<Tuple<int, int, TValue>>)input)
        {
        }
        public RangeCollection(IEnumerable<Tuple<int, int, TValue>> input)
        {
            var tuples = input.OrderBy(tuple => tuple.Item1).ToArray();
            for (var i = 1; i < tuples.Length; i++)
            {
                if (tuples[i].Item1 <= tuples[i - 1].Item2)
                {
                    throw new ArgumentException("Ranges should not overlap.");
                }
            }
            this._mins = new int[tuples.Length];
            this._maxs = new int[tuples.Length];
            this._values = new TValue[tuples.Length];
            for (var i = 0; i < tuples.Length; i++)
            {
                var tuple = tuples[i];
                this._mins[i] = tuple.Item1;
                this._maxs[i] = tuple.Item2;
                this._values[i] = tuple.Item3;
            }
        }
        public bool TryGetValue(int key, out TValue value)
        {
            if (this.Contains(key, out key))
            {
                value = this._values[key];
                return true;
            }
            value = default(TValue);
            return false;
        }
        public bool Contains(int key)
        {
            return this.Contains(key, out key);
        }
        private bool Contains(int key, out int index)
        {
            index = 0;
            if (this._mins.Length == 0 || key < this._mins[0] || key > this._maxs[this._maxs.Length - 1])
            {
                return false;
            }
            var low = 0;
            var high = this._mins.Length - 1;
            while (high >= low)
            {
                index = (low + high) / 2;
                var cmp = this._mins[index].CompareTo(key);
                if (cmp == 0)
                {
                    return true;
                }
                if (cmp == 1)
                {
                    high = index - 1;
                }
                else
                {
                    low = index + 1;
                }
            }
            if (this._mins[index] > key)
            {
                index--;
            }
            else if (this._mins[index + 1] <= key)
            {
                index++;
            }
            return this._maxs[index] >= key;
        }
    }
