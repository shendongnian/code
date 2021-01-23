    // All these names are bad... I don't know the domain here :)
    public class Publisher<T>
    {
        private readonly IObservable<T> observable;
        internal Publisher(IObservable<T> observable)
        {
            this.observable = observable;
        }
        public void OnClient<THub>(Expression<Func<THub, dynamic>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException(...);
            }
            string name = memberExpression.Member.Name;
            observable.Subscribe(x => Console.WriteLine(name));
        }
    }
    public static class ObservableExtensions
    {
        public static void Publish<T>(this IObservable<T> observable)
        {
            return new Publisher<T>(observable);
        }
    }
