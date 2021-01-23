    public T AttributeValue<T>(XmlNode node, string attributeName)
            {
                object value = null;
    
                if (node.Attributes[attributeName] != null && !string.IsNullOrEmpty(node.Attributes[attributeName].Value))
                    value = node.Attributes[attributeName].Value;
    
                if (typeof(T) == typeof(bool?) && value != null)
                    value = (string.Compare(value.ToString(), "1", true) == 0).ToString();
                
                var t = typeof(T);
                t = Nullable.GetUnderlyingType(t) ?? t;
    
                return (value == null) ?
                    default(T) : (T)Convert.ChangeType(value, t);
            }
