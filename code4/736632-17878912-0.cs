    public static ClassTwo(ClassOne one)
    {
      var two = new ClassTwo()
      {
        Name = one.Name,
        Code = one.Code,
        Mode = (ClassTwo.MyUserMode)((int)one.Mode);
      };
    }
