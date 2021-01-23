    public class GetObjectsComparison
    {
        public object FirstObject, SecondObject;
        public BindingFlags BindingFlagsConditions= BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
    }
    public struct SetObjectsComparison
    {
        public FieldInfo SecondObjectFieldInfo;
        public dynamic FirstObjectFieldInfoValue, SecondObjectFieldInfoValue;
        public bool ErrorFound;
        public GetObjectsComparison GetObjectsComparison;
    }
    private static bool ObjectsComparison(GetObjectsComparison GetObjectsComparison)
    {
        GetObjectsComparison FunctionGet = GetObjectsComparison;
        SetObjectsComparison FunctionSet = new SetObjectsComparison();
        if (FunctionSet.ErrorFound==false)
            foreach (FieldInfo FirstObjectFieldInfo in FunctionGet.FirstObject.GetType().GetFields(FunctionGet.BindingFlagsConditions))
            {
                FunctionSet.SecondObjectFieldInfo =
                FunctionGet.SecondObject.GetType().GetField(FirstObjectFieldInfo.Name, FunctionGet.BindingFlagsConditions);
    
                FunctionSet.FirstObjectFieldInfoValue = FirstObjectFieldInfo.GetValue(FunctionGet.FirstObject);
                FunctionSet.SecondObjectFieldInfoValue = FunctionSet.SecondObjectFieldInfo.GetValue(FunctionGet.SecondObject);
                if (FirstObjectFieldInfo.FieldType.IsNested)
                {
                    FunctionSet.GetObjectsComparison =
                    new GetObjectsComparison()
                    {
                        FirstObject = FunctionSet.FirstObjectFieldInfoValue
                        ,
                        SecondObject = FunctionSet.SecondObjectFieldInfoValue
                    };
    
                    if (!ObjectsComparison(FunctionSet.GetObjectsComparison))
                    {
                        FunctionSet.ErrorFound = true;
                        break;
                    }
                }
                else if (FunctionSet.FirstObjectFieldInfoValue != FunctionSet.SecondObjectFieldInfoValue)
                {
                    FunctionSet.ErrorFound = true;
                    break;
                }
            }
        return !FunctionSet.ErrorFound;
    }
