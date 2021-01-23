    public static class PropertyChangedExtensions
    {
        public static void RegisterPropertyHandler<T, TProperty>(this T obj, Expression<Func<T, TProperty>> propertyExpression, PropertyChangedEventHandler handlerDelegate)
            where T : class, INotifyPropertyChanged
        {
            if (obj == null) throw new ArgumentNullException("obj");
            var propertyName = GetPropertyName(propertyExpression);
            obj.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == propertyName && handlerDelegate != null)
                        handlerDelegate(sender, args);
                };
        }
        public static void Notify<T>(this PropertyChangedEventHandler eventHandler, object sender, Expression<Func<T>> propertyExpression)
        {
            var handler = eventHandler;
            if (handler != null) handler(sender, new PropertyChangedEventArgs(GetPropertyName(propertyExpression)));
        }
        private static string GetPropertyName(LambdaExpression propertyExpression)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = propertyExpression.Body as UnaryExpression;
                if (unaryExpression == null) 
                    throw new ArgumentException("Expression must be a UnaryExpression.", "propertyExpression");
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            if (memberExpression == null) 
                throw new ArgumentException("Expression must be a MemberExpression.", "propertyExpression");
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null) 
                throw new ArgumentException("Expression must be a Property.", "propertyExpression");
            return propertyInfo.Name;
        }
    }
