    public void NotifyPropertyChanged()
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            if (!(method.Name.StartsWith("get_") || method.Name.StartsWith("set_")))
            {
                throw new InvalidOperationException("The NotifyPropertyChanged() method can only be used from inside a property");
            }
            string propertyName = method.Name.Substring(4);
            RaisePropertyChanged(propertyName);
        }
