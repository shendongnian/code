    [Guid("3B81B6B7-3AF9-454F-AADF-FAF06E5A98F2")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IFunctions
    {
        int MYINT();
    }
 
    [Guid("F58C591D-A22F-49AD-BC21-A086097DC26B")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Functions : IFunctions 
    {
        public int MYINT()
        {
            return 42;
        }
    }
