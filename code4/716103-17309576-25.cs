    public class EnumComparer<TEnum>: IComparer<TEnum>, IEnumerable<TEnum> where TEnum: struct, IConvertible {
        protected static IList<TEnum> TypicalValues { get; set; }
        
        protected IList<TEnum> _reorderedValues;
        
        protected IList<TEnum> ReorderedValues { 
            get { return _reorderedValues.Any() ? _reorderedValues : TypicalValues; } 
            set { _reorderedValues = value; }
        } 
        
        static EnumComparer() {
            if (!typeof(TEnum).IsEnum) 
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            TypicalValues = new List<TEnum>();
            foreach (TEnum value in Enum.GetValues(typeof(TEnum))) {
                TypicalValues.Add(value);
            };            
        }
        
        public EnumComparer(IList<TEnum> reorderedValues = null) {
            if (_reorderedValues == null ) {
                _reorderedValues = new List<TEnum>();
                
                return;
            }
            
            _reorderedValues = reorderedValues;
        }
        
        public void Add(TEnum value) {
            if (_reorderedValues.Contains(value))
                return;
                
            _reorderedValues.Add(value);
        }
        
        public int Compare(TEnum x, TEnum y) {
            var xIndex = ReorderedValues.IndexOf(x);
            var yIndex = ReorderedValues.IndexOf(y);
            
            // no such enums in our order list:
            // so this enum values must be in the end
            //   and must be ordered between themselves by default
            
            if (xIndex == -1) {
                if (yIndex == -1) {
                    xIndex = TypicalValues.IndexOf(x);
                    yIndex = TypicalValues.IndexOf(y);
                    return xIndex.CompareTo(yIndex);                
                }
               
               return -1;
            }
            
            if (yIndex == -1) {
                return -1; //
            }
            
            return xIndex.CompareTo(yIndex);
        }
        
        public void Clear() {
            _reorderedValues = new List<TEnum>();
        }
        
        private IEnumerable<TEnum> GetEnumerable() {
            return Enumerable.Concat(
                ReorderedValues,
                TypicalValues.Where(v => !ReorderedValues.Contains(v))
            );
        }
        
        public IEnumerator<TEnum> GetEnumerator() {
            return GetEnumerable().GetEnumerator();            
        }
        
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerable().GetEnumerator();            
        }
    }
