    public static class FieldAndTypeExtensions {
        public static IEnumerable<FieldInfo> walk(this Type t) {
            foreach (FieldInfo f in t.GetFields()) {
                foreach (FieldInfo nextField in f.walk()) {
                    yield return nextField;
                }
            }
        }
        public static IEnumerable<FieldInfo> walk(this FieldInfo f) {
            yield return f;
            FieldInfo[] fieldInfos = f.FieldType.GetFields();
            foreach (FieldInfo nextField in fieldInfos) {
                foreach (FieldInfo anotherNext in nextField.walk()) {
                    yield return anotherNext;
                }
            }
        }
    }
