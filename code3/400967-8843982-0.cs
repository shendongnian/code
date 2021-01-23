    private MyDelegate _EventA;
    public event MyDelegate EventA
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        add 
        { 
            _EventA = (MyDelegate)Delegate.Combine(_EventA, value);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        remove 
        { 
            _EventA = (MyDelegate)Delegate.Remove(_EventA, value);
        }
    }
