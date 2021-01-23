    Type[] typeParamList = new Type[] { typeof(CustomSheetView), typeof(DataConsolidate) } //And 9 more
    MethodInfo method = typeof(Extensions).GetMethod("InsertElementAfter");
    foreach (var type in typeParamList)
    {
        var genericMethod = method.MakeGenericMethod(new Type[] { type });
        genericMethod.Invoke(worksheet, new object[] { mergeCells });
    }
