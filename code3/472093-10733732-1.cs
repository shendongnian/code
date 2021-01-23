        public static Nullable<T> GetEnumValue<T>(int? value) 
            where T : struct
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                var enumValues = Enum.GetValues(typeof(T));
                foreach (object enumValue in enumValues)
                {
                    if (Convert.ToInt32(enumValue).Equals(value))
                    {
                        return (T)enumValue;
                    }
                }
            }
            catch (ArgumentNullException)
            {
            }
            catch (ArgumentException)
            {
            }
            catch
            {
            }
            return null;
        }
