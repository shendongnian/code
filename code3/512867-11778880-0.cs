    bool CheckNegative(object number)
    {
        switch(Type.GetTypeCode(number.GetType())) {
            case TypeCode.Int32:
                return (int)number < 0;
            case TypeCode.Single:
                return (float)number < 0;
            // etc etc
            default:
                throw new ArgumentException();
    	}
    }
