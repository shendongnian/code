    var targetType =Type.GetType("System.Collections.Generic.IReadOnlyList`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
    
    var list = new List<string>{"lala", "la","lala"};
    object readonlyList;
    if(targetType != null){
        readonlyList = Impromptu.DynamicActLike(list, targetType);
    }
