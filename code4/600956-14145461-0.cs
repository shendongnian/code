    public class PredicateBuilder<TParameter>
    {
        private const int MaxPredicateConditionCount = 500;
        private readonly List<Expression<Func<TParameter, bool>>> _existingPredicates = new List<Expression<Func<TParameter, bool>>>(MaxPredicateConditionCount);
        private readonly ParameterExpression _parameter = Expression.Parameter(typeof(TParameter));
        private Expression<Func<TParameter, bool>> _expression;
        private Expression _workingPredicate;
        private int _workingPredicateConditionCount;
        public bool Built { get; private set; }
        public Expression<Func<TParameter, bool>> LambdaExpression
        {
            get
            {
                if (!Built)
                {
                    return null;
                }
                return _expression;
            }
        }
        public void AddCondition<TValue>(string propertyName, TValue value)
        {
            if (Built)
            {
                throw new InvalidOperationException("Predicate has already been built");
            }
            var property = Expression.Property(_parameter, propertyName);
            var constant = Expression.Constant(value, typeof(TValue));
            var equality = Expression.Equal(property, constant);
            if (_workingPredicate == null)
            {
                _workingPredicate = equality;
            }
            else
            {
                if (MaxPredicateConditionCount < ++_workingPredicateConditionCount)
                {
                    var compiledWorking = Expression.Lambda<Func<TParameter, bool>>(_workingPredicate, _parameter).Compile();
                    _existingPredicates.Add(p => compiledWorking(p));
                    if (_existingPredicates.Count + 1 > MaxPredicateConditionCount)
                    {
                        var compiled = BuildExistingPredicates().Compile();
                        _existingPredicates.Clear();
                        _existingPredicates.Add(p => compiled(p));
                    }
                    _workingPredicate = equality;
                    _workingPredicateConditionCount = 0;
                }
                else
                {
                    _workingPredicate = Expression.OrElse(_workingPredicate, equality);
                }
            }
        }
        private Expression<Func<TParameter, bool>> BuildExistingPredicates()
        {
            Expression compileTemp = Expression.Invoke(_existingPredicates[0], _parameter);
            for (var i = 1; i < _existingPredicates.Count; ++i)
            {
                var nextCall = Expression.Invoke(_existingPredicates[i], _parameter);
                compileTemp = Expression.OrElse(compileTemp, nextCall);
            }
            return Expression.Lambda<Func<TParameter, bool>>(compileTemp, _parameter);
        }
        public void Build()
        {
            Built = true;
            //There were no conditions, assume true
            if (_workingPredicate == null)
            {
                _expression = x => true;
                return;
            }
            _existingPredicates.Add(Expression.Lambda<Func<TParameter, bool>>(_workingPredicate, _parameter));
            _expression = BuildExistingPredicates();
            _existingPredicates.Clear();
            _workingPredicate = null;
            _workingPredicateConditionCount = 0;
        }
        public Func<TParameter, bool> Compile()
        {
            if (!Built)
            {
                Build();
            }
            return _expression.Compile();
        }
    }
