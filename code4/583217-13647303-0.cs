    public interface ISample
    {
        int[] YourArray
        {
            [return:MarshalAs(UnmanagedType.SafeArray)]
            get;
        }
