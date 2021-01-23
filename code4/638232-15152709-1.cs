    public static class SplitterPanelExtensions {
        public static void MyAdvancedMethod(this SplitterPanel splitterPanel) {
            /*
             * Check if splitterPanel is null and throw ArgumentNullException.
             * because extension methods are called via "call" IL instruction.
             */
            //Implementation.
        }
        //Other extension methods...
    }
