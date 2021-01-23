    public static class DirtyExtensions {
        private class ExtraPropertyHolder {
            public bool IsDirty { get; set; }
        }
    
        private static readonly ConditionalWeakTable<Control, ExtraPropertyHolder> _isDirtyTable 
            = new ConditionalWeakTable<Control, ExtraPropertyHolder>();    
    
        public static bool IsDirty(this Control @this) {
            return _isDirtyTable.GetOrCreateValue(@this).IsDirty;
        }
    
        public static void SetIsDirty(this Control @this, bool isDirty) {
            _isDirtyTable.GetOrCreateValue(@this).IsDirty = value;
        }
    }
