    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert all DateTime fields in a complex object from UTC to a destination time zone.
        /// </summary>
        /// <typeparam name="TInput">Type of an object that will be converted.</typeparam>
        /// <param name="obj">Object that will be deeply converted.</param>
        /// <param name="destTimeZone"><c>TimeZoneInfo</c> object of a destination time zone.</param>
        public static void DeepConvertFromUtc<TInput>(this TInput obj, TimeZoneInfo destTimeZone)
            where TInput : class
        {
            obj.DeepConvert(TimeZoneInfo.Utc, destTimeZone);
        }
        /// <summary>
        /// Convert all DateTime fields in a complex object from source time zone to UTC.
        /// </summary>
        /// <typeparam name="TInput">Type of an object that will be converted.</typeparam>
        /// <param name="obj">Object that will be deeply converted.</param>
        /// <param name="sourceTimeZone"><c>TimeZoneInfo</c> object of a source time zone.</param>
        public static void DeepConvertToUtc<TInput>(this TInput obj, TimeZoneInfo sourceTimeZone)
            where TInput : class
        {
            obj.DeepConvert(sourceTimeZone, TimeZoneInfo.Utc);
        }
        /// <summary>
        /// Convert all DateTime fields in a complex object from UTC to a destination time zone.
        /// </summary>
        /// <typeparam name="TInput">Type of an object that will be converted.</typeparam>
        /// <param name="obj">Object that will be deeply converted.</param>
        /// <param name="sourceTimeZone"><c>TimeZoneInfo</c> object of a source time zone.</param>
        /// <param name="destTimeZone"><c>TimeZoneInfo</c> object of a destination time zone.</param>
        public static void DeepConvertTime<TInput>(this TInput obj, TimeZoneInfo sourceTimeZone, TimeZoneInfo destTimeZone)
            where TInput : class
        {
            obj.DeepConvert(sourceTimeZone, destTimeZone);
        }
        private static void DeepConvert<TInput>(this TInput obj, TimeZoneInfo sourceTimeZone, TimeZoneInfo destTimeZone)
            where TInput : class
        {
            if (obj == null)
            {
                return;
            }
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                {
                    prop.ConvertDateTime(obj, sourceTimeZone, destTimeZone);
                    continue;
                }
                var value = prop.GetValue(obj);
                var list = value as IList;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        item.DeepConvert(sourceTimeZone, destTimeZone);
                    }
                    continue;
                }
                // here I check that an object is located in one of my assemblies
                if (prop.PropertyType.Assembly.FullName.StartsWith("Should be your namespace"))
                {
                    value.DeepConvert(sourceTimeZone, destTimeZone);
                }
            }
        }
        private static void ConvertDateTime<TInput>(this PropertyInfo prop, TInput obj, TimeZoneInfo sourceTimeZone, TimeZoneInfo destTimeZone)
            where TInput : class
        {
            var value = prop.GetValue(obj);
            if (value != null)
            {
                var dateTime = DateTime.SpecifyKind((DateTime)value, DateTimeKind.Unspecified);
                value = TimeZoneInfo.ConvertTime(dateTime, sourceTimeZone, destTimeZone);
                var setMethod = prop.SetMethod;
                if (setMethod != null)
                {
                    setMethod.Invoke(obj, new[] { value });
                }
            }
        }
    }
