/// <summary>
/// Cycle by types when in enum exist string reference on type (helper)
/// </summary>
/// <param name="container"></param>
/// <returns></returns>
public static Types GetCurrentType(string container) {
    foreach (Types t in Enum.GetValues(typeof(Types))) {
        if (container.Contains(t.GetFlagValue())) {
            return t;
        }
    }
    return Types.NULLABLE;
}
/// <summary>
/// Return object converted to type
/// </summary>
/// <param name="strCurrentDatatype"></param>
/// <param name="valueObj"></param>
/// <returns></returns>
public static object GetValueByValidating(string strCurrentDatatype, object valueObj) {
    var _value = valueObj != null ? valueObj : null;
    try {
        Types _current = _value != null ? GetCurrentType(strCurrentDatatype.ToLower()) : Types.NULLABLE;
        switch (_current) {
            case Types.INT:
                valueObj = Convert.ToInt32(valueObj);
                break;
            case Types.DECIMAL:
                valueObj = Convert.ToDecimal(valueObj);
                break;
            case Types.DOUBLE:
                valueObj = Convert.ToDouble(valueObj);
                break;
            case Types.REAL:
                valueObj = Convert.ToDouble(valueObj);
                break;
            case Types.STRING:
                valueObj = Convert.ToString(valueObj);
                break;
            case Types.OBJECT:
                break;
            case Types.NULLABLE:
                throw new InvalidCastException("Type not handled before selecting, function crashed by retype var.");
        }
    } catch (InvalidCastException ex) {
        Log.WriteException(ex);
        valueObj = false;
    }
    return valueObj;
}
