    // Shared source file
    [ComVisible(true)]
    public class Foo
    {
    }
    // Dummy class in Compact Framework or PCL project -- exists only to facilitate compilation of the shared source file
    namespace System
    {
        [AttributeUsage(AttributeTarget.Class)]
        public class ComVisibleAttribute : Attribute
        {
            public ComVisibleAttribue(bool visible)
            {
                // Dummy implementation
            }
        }
    }
