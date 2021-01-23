    public class MethodImplSetting
    {
        public const MethodImplOptions DEFAULT_METHOD_IMPL = MethodImplOptions.AggressiveInlining;
    }
    
    [MethodImpl(DEFAULT_METHOD_IMPL)]
    public void MyMethod()
    {
    
    }
