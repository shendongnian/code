    public static IDictionary<TKey, TValue>AnonymousObjectToHtmlAttributes<TKey, TValue>(object htmlAttributes) {
        IDictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
        if (htmlAttributes != null) {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes)) {
                result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
            }
        }
        return result;
    }
