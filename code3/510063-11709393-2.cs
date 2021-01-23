    private static AnimalTypeEnum GetAnimalFromInput()
    {
        AnimalTypeEnum animal;
        string s = Console.ReadLine();
        if (Enum.TryParse(s, true, out animal))
            return animal;
        else
        {
            Console.WriteLine(s + " is not valid, please try again");
            return GetAnimalFromInput();
        }
    }
