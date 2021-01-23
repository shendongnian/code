    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        private IDispatcherService dispatcher;
        // inject dispatcher service by unity
        [Dependency]
        public IDispatcherService Dispatcher { set { dispatcher = value; } }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// fires the property changed event
        /// </summary>
        /// <param name="value"></param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
                if (memberExpression != null)
                {
                    dispatcher.Invoke(() => 
                        handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name))
                    );
                }
                else
                {
                    throw new ArgumentException("RaisePropertyChanged event was not raised with a property: " + propertyExpression);
                }
            }
        }
    }
