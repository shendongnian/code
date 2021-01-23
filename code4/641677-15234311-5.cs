    public enum Test
    {
        UnitedStates,
        NewZealand
    }
    // from enum to string
    string result = Test.UnitedStates.ToNonPascalString(); // United States
    // from string to enum
    Test myEnum = EnumExtensions.EnumFromString<Test>("New Zealand");  // NewZealand
