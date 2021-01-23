    // in central assembly
    class Tool {
        private static Tool _t = new Tool();
        public static Tool T { get { return _t; } }
    }
    // in utility assembly 1
    public static class MyExtensionClassInAssembly1 {
        public static void SomeUtilityMethodX(this Tool tool, Object arg1, Object arg2) {
            // do something
        }
    }
    // in utility assembly 2
    public static class MyExtensionClassInAssembly2 {
        public static void SomeUtilityMethodY(this Tool tool) {
            // do something
        }
    }
