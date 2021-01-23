    string value = "Dog";
    PetType pet;
    if (Enum.TryParse<PetType>(value, out pet))
    {
        if (pet == PetType.Dog)
        {
            ...
        }
    }
    else
    {
        // Show an error message to the user telling him that the value string
        // couldn't be parsed back to the PetType enum
    }
