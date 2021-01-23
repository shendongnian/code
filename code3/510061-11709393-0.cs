    private static AnimalTypeEnum GetAnimalFromInput()
    {
        AnimalTypeEnum animal;
        string s = Console.ReadLine();
        switch (s.ToLower())
        {
            case "dog":
                animal = AnimalTypeEnum.DOG;
                break;
            case "cat":
                animal = AnimalTypeEnum.CAT;
                break;
            case "rabbit":
                animal = AnimalTypeEnum.RABBIT;
                break;
            default:
                Console.WriteLine(s + " is not valid, please try again");
                animal = GetAnimalFromInput();
                break;
        }
        return animal;
    }
    static void Main(string[] args)
    {
        AnimalTypeEnum animal = GetAnimalFromInput();
        Console.WriteLine(animal);
    }
