    /// <summary>
    /// Used to store the value of the primary key for a table.
    /// </summary>
    public sealed class PrimaryValue
    {
        /// <summary>
        /// The raw value
        /// </summary>
        private object _value;
        /// <summary>
        /// The required type.
        /// </summary>
        private Type _type;
        /// <summary>
        /// True if a Guid type.
        /// </summary>
        public bool IsGUID
        {
            get
            {
                return _type == typeof(Guid);
            }
        }
        /// <summary>
        /// Type if a uint type.
        /// </summary>
        public bool IsInteger
        {
            get
            {
                return _type == typeof(uint);
            }
        }
        /// <summary>
        /// True if the value is empty.
        /// </summary>
        public bool Empty
        {
            get
            {
                if (_type == typeof(uint))
                {
                    return (uint)_value == 0;
                }
                return (Guid)_value == Guid.Empty;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public PrimaryValue(Type pType)
        {
            _type = pType;
            if (pType == typeof(uint))
            {
                _value = 0;
            }
            else if (pType == typeof(Guid))
            {
                _value = Guid.Empty;
            }
            else
            {
                throw new ModelException("Type not supported by PrimaryValue.");
            }
        }
        /// <summary>
        /// UINT constructor.
        /// </summary>
        public PrimaryValue(uint pValue)
        {
            _value = pValue;
            _type = typeof(uint);
        }
        /// <summary>
        /// GUID constructor
        /// </summary>
        public PrimaryValue(Guid pValue)
        {
            _value = pValue;
            _type = typeof(Guid);
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        public PrimaryValue(PrimaryValue pValue)
        {
            _value = pValue._value;
            _type = pValue._type;
        }
        public void set(PrimaryValue pValue)
        {
            if (_type == pValue._type)
            {
                _value = pValue._value;
                return;
            }
            throw new ModelException("PrimaryValues are not of the same type.");
        }
        /// <summary>
        /// Assigns a UINT value.
        /// </summary>
        public void set(uint pValue)
        {
            if (_type == typeof(uint))
            {
                _value = pValue;
                return;
            }
            throw new ModelException("PrimaryValue is not a UINT type.");
        }
        /// <summary>
        /// Assigns a GUID value.
        /// </summary>
        public void set(Guid pValue)
        {
            if (_type == typeof(Guid))
            {
                _value = pValue;
                return;
            }
            throw new ModelException("PrimaryValue is not a GUID type.");
        }
        /// <summary>
        /// Returns the raw value.
        /// </summary>
        public object get()
        {
            return _value;
        }
        /// <summary>
        /// Gets the ID as UINT.
        /// </summary>
        public uint ToInteger()
        {
            if (_type != typeof(uint))
            {
                throw new ModelException("PrimaryValue is not a UINT type.");
            }
            return (uint)_value;
        }
        /// <summary>
        /// Gets the ID as GUID.
        /// </summary>
        public Guid ToGuid()
        {
            if (_type != typeof(Guid))
            {
                throw new ModelException("PrimaryValue is not a GUID type.");
            }
            return (Guid)_value;
        }
        /// <summary>
        /// Checks if two IDs are equal.
        /// </summary>
        public static bool operator ==(PrimaryValue A, PrimaryValue B)
        {
            if (A._value.GetType() == B._value.GetType())
            {
                return A._value == B._value;
            }
            throw new ModelException("Can not compare PrimaryValues of different types.");
        }
        /// <summary>
        /// Checks if two IDs are not equal.
        /// </summary>
        public static bool operator !=(PrimaryValue A, PrimaryValue B)
        {
            if (A._value.GetType() == B._value.GetType())
            {
                return A._value != B._value;
            }
            throw new ModelException("Can not compare PrimaryValues of different types.");
        }
        /// <summary>
        /// Convertion to UINT.
        /// </summary>
        public static implicit operator uint(PrimaryValue A)
        {
            return A.ToInteger();
        }
        /// <summary>
        /// Convertion to Guid.
        /// </summary>
        public static implicit operator Guid(PrimaryValue A)
        {
            return A.ToGuid();
        }
        /// <summary>
        /// Convertion to string.
        /// </summary>
        public static implicit operator string(PrimaryValue A)
        {
            return A._value.ToString();
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        public override string ToString()
        {
            return _value.ToString();
        }
        /// <summary>
        /// Hashcode
        /// </summary>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
