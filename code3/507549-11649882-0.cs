    /// <summary>
    /// Sample model binder that manually binds customer models
    /// </summary>
    public class CustomModelBinder : IModelBinder
    {
        /// <summary>
        /// Bind to the given model type
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="modelType">Model type to bind to</param>
        /// <param name="blackList">Blacklisted property names</param>
        /// <returns>Bound model</returns>
        public object Bind(NancyContext context, Type modelType, params string[] blackList)
        {
            var parentObject = Activator.CreateInstance(modelType);
            foreach (var key in context.Request.Form)
            {
                var value = context.Request.Form[key];
                this.SetObjectValue(parentObject, modelType, key, value);
            }
            return parentObject;
        }
        /// <summary>
        /// Sets the object value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="type">The type.</param>
        /// <param name="key">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        private void SetObjectValue(object instance, Type type, string key, string propertyValue)
        {
            if (key.Contains("."))
            {
                this.SetObjectValueDeep(instance, type, key, propertyValue);
            }
            PropertyInfo propertyInfo = type.GetProperty(key);
            if (propertyInfo == null)
            {
                return;
            }
            propertyInfo.SetValue(instance, Convert.ChangeType(propertyValue, propertyInfo.PropertyType), null);
        }
        /// <summary>
        /// Sets the object value derp.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <param name="propertyValue">The property value.</param>
        private void SetObjectValueDeep(object instance, Type type, string key, string propertyValue)
        {
            var propList = key.Split('.').ToList();
            PropertyInfo propertyInfo = type.GetProperty(propList.First());
            if (propertyInfo == null)
            {
                return;
            }
            var childObject = propertyInfo.GetValue(instance, null);
            if (childObject == null)
            {
                childObject = Activator.CreateInstance(propertyInfo.PropertyType);
                propertyInfo.SetValue(instance, childObject, null);
            }
            propList.RemoveAt(0);
            var newKey = propList.Aggregate(string.Empty, (current, prop) => current + (prop + ".")).TrimEnd('.');
            if (newKey.Contains("."))
            {
                this.SetObjectValueDeep(childObject, childObject.GetType(), newKey, propertyValue);
            }
            else
            {
                this.SetObjectValue(childObject, childObject.GetType(), newKey, propertyValue);
            }
        }
        /// <summary>
        /// Determines whether this instance can bind the specified model type.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <returns>
        ///   <c>true</c> if this instance can bind the specified model type; otherwise, <c>false</c>.
        /// </returns>
        public bool CanBind(Type modelType)
        {
            return true;
        }
    }
