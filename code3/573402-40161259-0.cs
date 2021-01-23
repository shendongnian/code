    public abstract class ObservableBase : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Members
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();
        #endregion
        #region Events
        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Protected Methods
        /// <summary>
        /// Get the string name for the property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression) expression.Body;
            return memberExpression.Member.Name;
        }
        /// <summary>
        /// Notify Property Changed (Shorted method name)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        protected virtual void Notify<T>(Expression<Func<T>> expression)
        {
            string propertyName = this.GetPropertyName(expression);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            string propertyName = this.GetPropertyName(expression);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        public string Error => null;
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid => this.errors.Count == 0;
        #endregion
        #region Indexer
        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();
                string error = null;
                if (Validator.TryValidateProperty(GetType().GetProperty(columnName).GetValue(this), new ValidationContext(this) { MemberName = columnName }, validationResults))
                {
                    this.errors.Remove(columnName);
                }
                else
                {
                    error = validationResults.First().ErrorMessage;
                    if (this.errors.ContainsKey(columnName))
                    {
                        this.errors[columnName] = error;
                    }
                    else
                    {
                        this.errors.Add(columnName, error);
                    }
                }
                this.OnPropertyChanged(() => this.IsValid);
                return error;
            }
        }
        #endregion  
    }
