    private static Func<TConcrete> _createFunc;
        private static TConcrete CreateNew()
        {
                if (_func == null)
                {
                    _createFunc = Expression.Lambda<Func<TConcrete>>(Expression.New(typeof (TConcrete))).Compile();
                }
                return _createFunc.Invoke();
        }
        public TConcrete Add(IDistanceUnit unit)
        {
                TConcrete result = CreateNew();
                result.Value = Value + ToThis(unit).Value();
                return result;
        } 
