        public class MyFlatInj : FlatLoopValueInjection
        {
            protected override bool TypesMatch(Type sourceType, Type targetType)
            {
                var snt = Nullable.GetUnderlyingType(sourceType);
                var tnt = Nullable.GetUnderlyingType(targetType);
    
                return sourceType == targetType
                       || sourceType == tnt
                       || targetType == snt
                       || snt == tnt;
            }
        }
