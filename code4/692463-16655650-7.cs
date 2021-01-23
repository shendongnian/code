        #region < INotifyPropertyChanged > Members
        
        /// <summary>
        /// Is connected to a method which handle changes to a property (located in the WPF Data Binding Engine)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raise the [PropertyChanged] event
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        private Dictionary<string, object> propertyValueStorage;
        
        #region Constructor
        public NotifyPropertyChangedBase()
        {
            this.propertyValueStorage = new Dictionary<string, object>();
        }
        #endregion
        /// <summary>
        /// Set the value of the property and raise the [PropertyChanged] event
        /// (only if the saved value and the new value are not equal)
        /// </summary>
        /// <typeparam name="T">The property type</typeparam>
        /// <param name="property">The property as a lambda expression</param>
        /// <param name="value">The new value of the property</param>
        protected void SetValue<T>(Expression<Func<T>> property, T value)
        {
            LambdaExpression lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new ArgumentException("Invalid lambda expression", "Lambda expression return value can't be null");
            }
            string propertyName = this.getPropertyName(lambdaExpression);
            T storedValue = this.getValue<T>(propertyName);
            if (!object.Equals(storedValue, value))
            {
                this.propertyValueStorage[propertyName] = value;
                this.OnPropertyChanged(propertyName);
            }
        }
        /// <summary> Get the value of the property </summary>
        /// <typeparam name="T">The property type</typeparam>
        /// <param name="property">The property as a lambda expression</param>
        /// <returns>The value of the given property (or the default value)</returns>
        protected T GetValue<T>(Expression<Func<T>> property)
        {
            LambdaExpression lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new ArgumentException("Invalid lambda expression", "Lambda expression return value can't be null");
            }
            string propertyName = this.getPropertyName(lambdaExpression);
            return getValue<T>(propertyName);
        }
        /// <summary>
        /// Try to get the value from the internal dictionary of the given property name
        /// </summary>
        /// <typeparam name="T">The property type</typeparam>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>Retrieve the value from the internal dictionary</returns>
        private T getValue<T>(string propertyName)
        {
            object value;
            if (propertyValueStorage.TryGetValue(propertyName, out value))
            {
                return (T)value;
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// Extract the property name from a lambda expression
        /// </summary>
        /// <param name="lambdaExpression">The lambda expression with the property</param>
        /// <returns>The extracted property name</returns>
        private string getPropertyName(LambdaExpression lambdaExpression)
        {
            MemberExpression memberExpression;
            if (lambdaExpression.Body is UnaryExpression)
            {
                var unaryExpression = lambdaExpression.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambdaExpression.Body as MemberExpression;
            }
            return memberExpression.Member.Name;
        }
    } 
