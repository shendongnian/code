    IItem[] inventory = new IItem[2];
    inventory[0] = new Weapon { Name = "Singing Sword", Power = 10 };
    inventory[1] = new Armor { Name = "Chainmail Shirt", Resistance = 5 };
    // Travers all items
    foreach (Item item in inventory)
    {
        Console.WriteLine(item.Name);
    }
    // Traverse only Weapon items
    foreach (Weapon weapon in inventory.Where(i => i is Weapon))
    {
        Console.WriteLine(weapon.Power);
    }
    // Traverse only Armor items
    foreach (Armor armor in inventory.Where(i => i is Armor))
    {
        Console.WriteLine(armor.Resistance);
    }
