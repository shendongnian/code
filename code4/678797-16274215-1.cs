    ...
    else if (type.Contains("dark"))
    {
        M = 3;
        regularCoffee = new Regular(name, D, C, M);
        if (!Coffee.Find(inventory, regularCoffee))
        {
            inventory.Add(regularCoffee);
        }
    }
    ...
