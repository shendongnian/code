    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public abstract class ObservableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                    handler(this, e);
            }
    
            protected void SetValue<T>(ref T field, T value, string propertyName)
            {
                if (!EqualityComparer<T>.Default.Equals(field, value))
                {
                    field = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
