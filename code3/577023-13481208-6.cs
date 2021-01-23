    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var handler = PropertyChanged;
            var propertyName = GetPropertyName(propertyExpression);
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = propertyExpression.Body as UnaryExpression;
                if (unaryExpression == null) 
                    throw new ArgumentException("Expression must be a MemberExpression.", "propertyExpression");
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
