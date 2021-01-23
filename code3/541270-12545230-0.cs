    public Func<Player, bool> ByName(string name)
    {
        return new Func<Player, bool>(p => p.Name == name);
    }
    Player player = playerList.Find(ByName("Davy"));
    playerList.Remove(player);
