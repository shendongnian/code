    public event FooChangedHandler FooChanged
    {
        add { m_observable.ToEvent().OnNext += value; }
        remove { m_observable.ToEvent().OnNext -= value; }
    }
