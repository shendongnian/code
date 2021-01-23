    // Interface, in an assembly visible to both of the other assemblies.
    public interface IDLLInterface
    {
        int[] CallNewMethod();
    }
    // Implementation in the main program.
    class DefaultDLLImplementation : IDLLInterface
    {
        public int[] CallNewMethod()
        {
            return new int[5];
        }
    }
    static class DLLImplementation
    {
        public readonly IDLLInterface Instance;
        static DLLImplementation()
        {
            // Pseudo-code
            if (DllIsAvailable) {
                Instance = ConstructInstanceFromDllUsingReflection();
            } else {
                Instance = new DefaultDLLImplementation();
            }
        }
    }
