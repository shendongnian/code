    [Test]
    public void CreateJoinTable()
    {
        var character = new Character() {Name = "Wario", IsEvil = true};
        var videogame = new Videogame() {Name = "Super Mario Bros 20", ReleasedDate = DateTime.Now , Characters = new Collection<Character>()};
        videogame.Characters.Add(character);
        var context = new NerdContext();
        context.Add(videogame);
        context.SaveAllChanges();
    }
