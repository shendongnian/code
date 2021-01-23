    // in Stick
    foreach (Enchantment ItemEnchantment in Enchantments) {
        ItemEnchantment.Update(this);
    }
    // in Enchantment..
    public void Update(Stick stick) {
        stick.Damage += 2;
    }
