    public static ClassTwo(ClassOne one)
    {
      var mode = (ClassTwo.MyUserMode)((int)one.Mode);
      if (!Enum.IsDefined(typeof(ClassTwo.MyUserMode), mode)
        throw new InvalidOperationException("Cannot map enums.");
      var two = new ClassTwo()
      {
        Name = one.Name,
        Code = one.Code,
        Mode = mode
      };
    }
