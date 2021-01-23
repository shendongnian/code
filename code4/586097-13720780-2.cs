    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Helper method to set the value of a property and notify if the value has changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newValue">The value to set the property to.</param>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="notify">Flag indicating whether there should be notification if the value has changed.</param>
        /// <param name="notifications">The property names to notify that have been changed.</param>
        protected bool SetProperty<T>(ref T newValue, ref T currentValue, bool notify, params string[] notifications)
        {
            if (EqualityComparer<T>.Default.Equals(newValue, currentValue))
                return false;
            currentValue = newValue;
            if (notify && notifications.Length > 0)
                foreach (string propertyName in notifications)
                    OnPropertyChanged(propertyName);
            return true;
        }
        /// <summary>
        /// Raises the <see cref="E:PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
    }
