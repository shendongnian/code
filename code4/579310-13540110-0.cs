        public static void setIfNull<T>(this ref T i_ObjectToUpdate, T i_DefaultValue)
        {
            if (EqualityComparer<T>.Default.Equals(i_ObjectToUpdate, default(T)))
            {
                i_ObjectToUpdate = i_DefaultValue;
            }
        }
