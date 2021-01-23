    object objB = ObjA.ObjB();
    Type objBType = objB.GetType();
    System.Reflection.PropertyInfo objCInfo = objBType.GetProperty("ObjC");
    object val = objCInfo.GetValue(objB);
    Type objCType = val.GetType();
    System.Reflection.PropertyInfo PropAInfo = objCType.GetProperty("PropA");
    PropAInfo.SetValue(val, propValue, null);
