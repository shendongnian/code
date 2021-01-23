        protected T SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return value;
            }
            NotifyPropertyChanging(propertyName);
            field = value;
            NotifyPropertyChanged(propertyName);
            return value;
        }
        protected T SetProperty<T>(ref EntityRef<T> field, T value, [CallerMemberName] string propertyName = null)
        {
            NotifyPropertyChanging(propertyName);
            field.Entity = value;
            NotifyPropertyChanged(propertyName);
            return value;
        }
