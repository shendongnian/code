    public override bool Equals(object obj)
    {
        var other = obj as AccountBase;
        return other != null && IsTransient ? ReferenceEquals(this, other) : Id == other.Id;
    }
    
    private bool IsTransient { get { return Id == 0; } }
    
    private int? _cachedHashcode;
    public override int GetHashcode()
    {
        if (!_cachedHashcode.HasValue)
            _cachedHashcode = IsTransient ? base.GetHashCode() : Id.GetHashCode();
        return _cachedHashcode.Value;
    }
