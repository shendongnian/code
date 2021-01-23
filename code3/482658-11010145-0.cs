    object obj = new BaseClass();
    obj = obj.GetType().GetProperty("Prpty1").GetValue(obj, null);
    obj = obj.GetType().GetProperty("Prpty2").GetValue(obj, null);
    obj = obj.GetType().GetProperty("Prpty3").GetValue(obj, null);
    string s = obj.ToString(); // "Test value"
