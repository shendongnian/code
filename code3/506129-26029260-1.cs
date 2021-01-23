    public class ClassName<T> {
        private T _genericType;
        public ClassName(T t) {
            _genericType = t;
        }
    
        public void UseGenericType() {
            // Code below allows you to get RowKey property from your generic 
            // class type param T, cause you can't directly call _genericType.RowKey
            PropertyInfo rowKeyProp = _genericType.GetType().GetProperty("RowKey");
            if(rowKeyProp != null) { // if T has RowKey property, my case different T has different properties and methods
                string rowKey = rowKeyProp.GetValue(_genericType).ToString();
                // Set RowKey property to new value
                rowKeyProp.setValue(_genericType, "new row key");
            }
        }
    }
