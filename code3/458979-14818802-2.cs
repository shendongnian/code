    public class SubSet<T>
    {
        private IList<T> _list;
        private int _length;
        private int _max;
        private int _count;
        public SubSet(IList<T> list)
        {
            if (list== null)
                throw new ArgumentNullException("lista");
            _list = list;
            _length = _list.Count;
            _count = 0;
            _max = (int)Math.Pow(2, _length);
        }
        
        public IList<T> Next()
        {
            if (_count == _max)
            {
                return null;
            }
            uint rs = 0;
            IList<T> l = new List<T>();            
            while (rs < _length)
            {
                if ((_count & (1u << (int)rs)) > 0)
                {
                    l.Add(_list[(int)rs]);                    
                }
                rs++;
            }
            _count++;
            return l;            
        }
    }
