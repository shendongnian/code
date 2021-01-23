    static bool IsHex(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length < 3)
            return false;
        const byte State_Zero = 0;
        const byte State_X = 1;
        const byte State_Value = 2;
        var state = State_Zero;
        for (var i = 0; i < value.Length; i++)
        {
            switch (value[i])
            {
                case '0': 
                    {
                        // Can be used in either Value or Zero.
                        switch (state)
                        {
                            case State_Zero: state = State_X; break;
                            case State_X: return false;
                            case State_Value: break;
                        }
                    }
                    break;
                case 'X': case 'x': 
                    {
                        // Only valid in X.
                        switch (state)
                        {
                            case State_Zero: return false;
                            case State_X: state = State_Value; break;
                            case State_Value: return false;
                        }
                    }
                    break;
                case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                case 'A': case 'B': case 'C': case 'D': case 'E': case 'F':
                case 'a': case 'b': case 'c': case 'd': case 'e': case 'f':
                    {
                        // Only valid in Value.
                        switch (state)
                        {
                            case State_Zero: return false;
                            case State_X: return false;
                            case State_Value: break;
                        }
                    }
                    break;
                default: return false;
            }
        }
        return state == State_Value;
    }
