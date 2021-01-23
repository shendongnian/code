    var columns = parser.ReadFields();
    for (var i = 0; i < columns.Length; i++)
    {
        SetValue(call, i, columns[i]);
    }
    private static void SetValue(DispatchCall call, int column, string value)
    {
        switch column
        {
            case 0:
                SetValue(ref call.AccountId, (value) => int.Parse, value);
                return;
            case 1:
                SetValue(ref call.WorkOrder, (value) => value, value);
                return;
            ...
            default:
                throw new UnexpectedColumnException();
        }      
    }
    private static void SetValue<T>(
        ref T property,
        Func<string, T> setter
        value string)
    {
        property = setter(value);
    }
