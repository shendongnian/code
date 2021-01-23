        /// <summary>
        /// Gets the value of all the fields or properties on an object that are decorated with the specified attribute
        /// </summary>
        private IEnumerable<object> GetValuesFromAttributedMembers<TAttribute>(object obj)
            where TAttribute : Attribute
        {
            var values1 = obj.GetType().GetFields().Where(fi => fi.GetCustomAttributes(typeof(TAttribute), true).Any()).Select(fi => fi.GetValue(obj));
            var values2 = obj.GetType().GetProperties().Where(pi => pi.GetCustomAttributes(typeof(TAttribute), true).Any()).Select(pi => pi.GetValue(obj, null));
            return values1.Concat(values2);
        }
