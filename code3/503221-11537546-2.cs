        public void Assign<TResult>(TSource instance, TResult value)
        {
            var property = typeof(TSource).GetProperties().FirstOrDefault(p => p.PropertyType.IsAssignableFrom(typeof(TResult)));
            if (property != null)
            {
                property.SetValue(instance, value, new object[0]);
            }
        
        }
