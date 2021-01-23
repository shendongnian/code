    foreach (EnumType enumType in Enum.GetValues(typeof(EnumType)))
    {
        if (enumType.HasFlag(enumType))
        {
            Console.WriteLine(enumType.ToString());
        }
    }
