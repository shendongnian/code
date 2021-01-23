    int i = 10;
    string str = "";
    var isPrimitive = i.GetType().IsValueType || i is string; // returns true since i is value type
    var isPrimitiveWithString = str.GetType().IsValueType || str is string; 
     // returns true
    CustomClass obj = new CustomClass();
    var isPrimitive3 = obj.GetType().IsPrimitive; // returns false
