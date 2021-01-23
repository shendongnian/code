    private void SetField<T>(ref T field, T value) {
        if (Consumed) throw new InvalidOperationException();
        field = value;
    }
    public int ValueB {
        get { return _valueB; }
        set { SetField(ref _valueB, value); }
    }    
    public string ValueA {
        get { return _valueA; }
        set { SetField(ref _valueA, value); }
    }
