    // In C#:
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Person
    {
      [MarshalAs(UnmanagedType.LPWStr)] public string FirstName;
      [MarshalAs(UnmanagedType.LPWStr)] public string LastName;
      public int Age;
    }
    // In C++
    typedef struct tagPerson
    {
      LPWSTR firstname;
      LPWSTR lastname;
      LONG age;
    } Person;
