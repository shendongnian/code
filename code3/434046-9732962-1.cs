    public abstract class Level<TRange>
       where TRange : Ranges
    {
        private readonly TRange _range;
        protected Level(TRange range)
        {
            this._range = range;
        }
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
        public ALevel()
            : base (new ARange())
        {
        }
    }
