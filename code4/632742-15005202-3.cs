    public T GetValue() {
        if (_value == null) {
            throw new System.Exception("Value not yet present.");
        }
        return _value;
    }
    public T SetValue(T newValue) {
        lock (writeLock)
        {        
            if (newValue == null) {
                throw new System.ArgumentNullException();
            }
            _value = newValue;
            return newValue;
        }
    }
