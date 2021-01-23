    // keep the random generator around
    private readonly Random rand = new Random();
    // keep the stats around; even better: make an Enum with those values
    private readonly string[] stats = { "Power", "Precision", "Allure", "Vitality", "Essence" };
    private Card DrawNewCard ()
    {
        string stat = stats[random.Next(0, stats.Length)];
        int value = GetRandomValueForStat(stat);
        string name = string.Format("{0} of {1}", value, stat);
        return new Card(name, value, stat);
    }
    public void generateBattleCards()
    {
        CardHand.Clear();
        for (int i = 0; i < 5; i++)
        {
            CardHand.Add(DrawNewCard());
        }
    }
