    public static Func<MyClass, IComparable> GetKeySelector(int keyNum)
    {
        switch (keyNum) {
            case 1:
                return m => m.Name;
            case 2:
                return m => m.CreationTime;
            default:
                throw new ArgumentException();
        }
    }
    .OrderBy(MyClass.GetKeySelector(1));
