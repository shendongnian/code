    public sealed class Grob : IOldNewGrob
    {
        private static readonly Grob instance = new Grob();
        public static Grob Instance { get { return instance; } }
        // Prevent external instantiation
        private Grob() {}
        public static void Frob()
        {
            // Implementation
        }
        // Explicit interface implementation to prevent name collisions
        void IOldNewGrob.Frob()
        {
            // Call the static implementation
            Frob();
        }
    }
