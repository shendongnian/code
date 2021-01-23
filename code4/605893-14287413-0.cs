    public void Log<EnumType>(EnumType enumMember)
    {
        var name = enumMember.ToString();
        int value = (int)(object)enumMember;
        Console.WriteLine(name + " = " + value);
    }
