    private static T GetValueOfType<T>(this ManagementBaseObject MBO, String FieldName) {
        T lResult;
        try {
            Object lObj = MBO[FieldName];
            var lSrcType = lObj.GetType();
            var lDestType = typeof(T);
            if (lDestType.IsValueType && lDestType.IsAssignableFrom(lSrcType)) {
                lResult = (T)lObj;
                return lResult;
            }
            var lDestTC = TypeDescriptor.GetConverter(typeof(T));
            if (lDestTC.CanConvertFrom(lSrcType)) {
                lResult = (T)lDestTC.ConvertFrom(lObj);
            } else {
                var lSrcTC = TypeDescriptor.GetConverter(lSrcType);
                String lTmp = lSrcTC.ConvertToInvariantString(lObj);
                lResult = (T)lDestTC.ConvertFromInvariantString(lTmp);
            }
        } catch {
            lResult = default(T);
        }
        return lResult;
    }
