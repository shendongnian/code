    public string Title // Note: public fields, methods and properties use PascalCasing
    {
        get // This replaces your getTitle method
        {
            return _title; // Where _title is a field somewhere
        }
        set // And this replaces your setTitle method
        {
            _title = value; // value behaves like a method parameter
        }
    }
