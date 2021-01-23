    public Weapon getWeaponAtPositon(int index)
    {
        if (index > 0 && index < InventorySlots)
            return weapons[index];
        else
            return null;
    }
    public void setWeaponAtPositon(Weapon weapon, int index)
    {
        if (weapon != null && index > 0 && index < InventorySlots)
            weapons[index] = weapon;
    }
    public void deleteWeaponAtPositon(int index)
    {
        if (index > 0 && index < InventorySlots)
            weapons[index] = null;
    }
