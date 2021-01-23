    class Factory
    {
        public IActivity<T> GetActivity<T>()
        {
            Type type = typeof(T);
            if (type == typeof(DataTable))
                return (IActivity<T>)new ReportActivityManager();
            // etc
        }
    }
