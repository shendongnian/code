    public class Level<TRange>
        where TRange: Ranges
    {
        private readonly TRange _range;
        public TRange Range
        {
            get
            {
                return this._range;
            }
        }
    }
    public class ALevel : Level<ARange>
    {
    }
