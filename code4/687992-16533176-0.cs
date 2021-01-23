    public static Adventurer createAdventurer()
    {
        return new Adventurer();
    }
    private Adventurer()
    {
        Array valuesGender = Enum.GetValues(typeof(AdventurerGender));
        AdventurerGender randomGender = (AdventurerGender)valuesGender.GetValue(rand.Next(valuesGender.Length));
        Array valuesClass = Enum.GetValues(typeof(AdventurerClass));
        AdventurerClass randomClass = (AdventurerClass)valuesClass.GetValue(rand.Next(valuesClass.Length));
        string name = "Test " + AdventurerManager.AvaliableAdvList.Count.ToString();
        // TODO assign member values here
    }
