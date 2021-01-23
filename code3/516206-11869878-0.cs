    using System.ComponentModel;
...
    public T Convert<T>(object v) {
        return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(v);
    }
