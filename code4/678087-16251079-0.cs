    private static string RangeMessage {
        get {
            if(_rangeMessage == null) {
                _rangeMessage = Environment.GetResourceString(
                                            "Arg_ArgumentOutOfRangeException");
            }
            return _rangeMessage;
        }
    }
