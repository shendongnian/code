    class Factory
    {
        public IActivity<T> GetActivity<T>()
        {
            Type type = typeof(T);
            if (type == typeof(DataTable))
                return new ReportActivityManager();
            // etc
        }
    }
