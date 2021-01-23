    public class ValueWrapper<TData>
    {
        //Holders for out getter/setter
        private Action<TData> _assign;
        private Func<TData> _read;
        private ValueWrapper()
        {
        }
        //Creates a wrapper for a value that isn't an instance member of a class
        public static ValueWrapper<TData> Create(Expression<Func<TData>> selector)
        {
            var member = selector.Body;
            var param = Expression.Parameter(typeof (TData), "value");
            var assign = Expression.Assign(member, param);
            var assignFunc = Expression.Lambda<Action<TData>>(assign, param).Compile();
            var readFunc = Expression.Lambda<Func<TData>>(member).Compile();
            return new ValueWrapper<TData>
            {
                _assign = assignFunc,
                _read = readFunc
            };
        }
        //Creates a wrapper for a value that is an instance member of a class
        public static ValueWrapper<TData> Create<TOwner>(TOwner owner, Expression<Func<TOwner, TData>> selector)
        {
            var member = ((MemberExpression)selector.Body).Member;
            var ownerConst = Expression.Constant(owner, typeof (TOwner));
            var param = Expression.Parameter(typeof(TData), "value");
            var access = Expression.MakeMemberAccess(ownerConst, member);
            var assign = Expression.Assign(access, param);
            var assignFunc = Expression.Lambda<Action<TData>>(assign, param).Compile();
            var readFunc = Expression.Lambda<Func<TData>>(access).Compile();
            return new ValueWrapper<TData>
            {
                _assign = assignFunc,
                _read = readFunc
            };
        }
        //Gets the value from the wrapped source
        public TData Set(TData value)
        {
            _assign(value);
            return _read();
        }
        //Sets the value of the wrapped source
        public TData Get()
        {
            return _read();
        }
    }
