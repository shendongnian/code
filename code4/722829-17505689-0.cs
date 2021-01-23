    public static class ObjectExtensions {
        public static bool IsOneOfTypes(this object o, params Type[] types) {
            Contract.Requires(o != null);
            Contract.Requires(types != null);
            return types.Any(type => type == o.GetType());
        }
    }
