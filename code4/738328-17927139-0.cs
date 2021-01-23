    static string FruitType(int Type)
    {
        if (Enum.IsDefined(typeof(Fruits), Type))
        {
            return ((Fruits)Type).ToString();
        }
        else
        {
            return "Not defined"; 
        }
    }
