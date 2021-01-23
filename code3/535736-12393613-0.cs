    public void Test() {
        var one = FirstEnumWithSameValues.Two;
        var two = (SecondEnumWithSameValues) one;
        var three = FirstEnumWithSameName.Two.ToString();
        var four = (SecondEnumWithSameName) Enum.Parse(typeof(SecondEnumWithSameName), three);
    }
    public enum FirstEnumWithSameValues
    {
       One = 1,
       Two = 2,
       Three = 3
    }
    public enum SecondEnumWithSameValues
    {
        Uno = 1,
        Due = 2,
        Trez = 3
    }
    public enum FirstEnumWithSameName
    {
        One = 1,
        Two = 2,
        Three = 3
    }
    public enum SecondEnumWithSameName
    {
        One = 4,
        Two = 5,
        Three = 6
    }
