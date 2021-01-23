    interface IAccessibilityFeature<T>
    {
        List<T> Settings { get; set; }
    }
    
    class MyAccess : IAccessibilityFeature<MyAccess>
    {
        List<MyAccess> Settings { get; set; }
    }
