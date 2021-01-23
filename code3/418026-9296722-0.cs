    public class ExtensionData
    {
        //put your data here
    }
    public class Extended<T>
        where T : Control
    {
        public Extended( T baseControl )
        {
            BaseControl = baseControl;
        }
        public T BaseControl { get; set; }
        public ExtensionData Extension { get; set; }
    }
