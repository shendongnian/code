        public static string GetMemberName<T>(T item) where T : class
        {
            if (item == null)
                return null;
        
            return typeof(T).GetProperties()[0].Name;
        }
    
