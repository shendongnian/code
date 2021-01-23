    public static class AnonClassHelper {
        public static void SetField<T>(object anonClass, string fieldName, T value) {
            var field = anonClass.GetType().GetField($"<{fieldName}>i__Field", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(anonClass, value);
        }
    }
    // usage
    AnonClassHelper.SetField(inst, nameof(inst.SomeField), newVal);
