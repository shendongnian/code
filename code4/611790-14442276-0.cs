    foreach (EnumType enumType in Enum.GetValues(typeof(EnumType)))
    {
        if(enumVar.HasFlag(enumType)) 
        {
            Console.WriteLine(enumTpye.ToString());
        }
    }
