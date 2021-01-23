        public static bool Is<T>(this string s)
        {
            bool success = true;
            try
            {
                s.Cast<T>();
            }
            catch(Exception)
            {
                success = false;
            }
            return success;
        }
