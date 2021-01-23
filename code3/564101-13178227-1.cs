    public static class WhenAnyExtensions
    {
        public static CanExecuteObservable WhenAny(this IReactiveNotifyPropertyChanged obj,
            IEnumerable<Expression<Func<object>>> expressions, Func<bool> func)
        {
            return new CanExecuteObservable(obj, expressions, func);
        }
        public static CanExecuteObservable WhenAny(this IReactiveNotifyPropertyChanged obj, Expression<Func<object>> property1, Func<bool> func)
        {
            return obj.WhenAny(new[] { property1 }, func);
        }
        public static CanExecuteObservable WhenAny(this IReactiveNotifyPropertyChanged obj, Expression<Func<object>> property1, Expression<Func<object>> property2, Func<bool> func)
        {
            return obj.WhenAny(new[] { property1, property2 }, func);
        }
        //etc...
    }
    public class CanExecuteObservable : IObservable<bool>
    {
        internal CanExecuteObservable(IReactiveNotifyPropertyChanged obj,
            IEnumerable<Expression<Func<object>>> expressions, Func<bool> func)
        {
            this.func = func;
            AddProperties(expressions);
            obj
                .Changed
                .Where(oc => propertyNames.Any(propertyName => propertyName == oc.PropertyName))
                .Subscribe(oc => Fire());
        }
        private readonly List<string> propertyNames = new List<string>();
        private readonly Func<bool> func;
        public void AddProperties(IEnumerable<Expression<Func<object>>> expressions)
        {
            foreach (var expression in expressions)
            {
                string propertyName = ReflectionHelper.GetPropertyNameFromExpression(expression);
                propertyNames.Add(propertyName);
            }
        }
        public void AddProperties(Expression<Func<object>> property1) { AddProperties(new[] { property1 }); }
        public void AddProperties(Expression<Func<object>> property1, Expression<Func<object>> property2) { AddProperties(new[] { property1, property2 }); }
        //etc...
        public void Clear()
        {
            propertyNames.Clear();
        }
        private readonly Subject<bool> subject = new Subject<bool>();
        private void Fire()
        {
            subject.OnNext(func());
        }
        public IDisposable Subscribe(IObserver<bool> observer)
        {
            return subject.Subscribe(observer);
        }
    }
