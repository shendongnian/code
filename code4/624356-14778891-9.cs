    Item[] inventory = new Item[2];
    inventory[0] = new Weapon { Name = "Singing Sword", Power = 10 };
    inventory[1] = new Armor { Name = "Chainmail Shirt", Resistance = 5 };
    // Note below that the Name property is always accessible because it is defined in the base class.
    // Traverse only Weapon items
    foreach (Weapon weapon in inventory.OfType<Weapon>())
    {
        Console.WriteLine(weapon.Power);
    }
    // Traverse only Armor items
    foreach (Armor armor in inventory.OfType<Armor>())
    {
        Console.WriteLine(armor.Resistance);
    }
    // Travers all items
    foreach (Item item in inventory)
    {
        Console.WriteLine(item.Name);
    }
