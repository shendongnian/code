    private static T GetValueOfType<T>(this ManagementBaseObject MBO, String FieldName) {
        T lResult;
        try {
            var lDestTC = TypeDescriptor.GetConverter(typeof(T));
            Object lObj = MBO[FieldName];
            var lSourceType = lObj.GetType();
            if (lDestTC.CanConvertFrom(lSourceType)) {
                lResult = (T)lDestTC.ConvertFrom(lObj);
            } else {
                var lSrcTC = TypeDescriptor.GetConverter(lSourceType);
                String lTmp = lSrcTC.ConvertToInvariantString(lObj);
                lResult = (T)lDestTC.ConvertFromInvariantString(lTmp);
            }
        } catch {
            lResult = default(T);
        }
        return lResult;
    }
