    public override string ToString() { 
        StringBuilder s = StringBuilderCache.Acquire(); 
        s.Append('[');
        if( Key != null) { 
            s.Append(Key.ToString());
        }
        s.Append(", ");
        if( Value != null) { 
           s.Append(Value.ToString());
        } 
        s.Append(']'); 
        return StringBuilderCache.GetStringAndRelease(s);
    } 
