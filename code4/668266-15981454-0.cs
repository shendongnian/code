    public object Data {
        get {
            Contract.Ensures(Contract.Result<object>() == _data);
            ((SomeClass)_data).SomeProperty += 1;
            return _data;
        }
    }
