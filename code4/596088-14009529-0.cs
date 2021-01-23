    class Program
    {
        static void Main(string[] args)
        {
            List<ActionWithChance> list = new List<ActionWithChance>()
                                              {
                                                  new ActionWithChance("1", 100),
                                                  new ActionWithChance("2", 100),
                                                  new ActionWithChance("3", 100),
                                                  new ActionWithChance("4", 100),
                                                  new ActionWithChance("5", 100)
                                              };
    
            for (int i = 0; i < 10; i++)
            {
                RandomHandler.CreateIntervals(list);
                RandomHandler.GetRandom(list);
            }
    
    
        }
    }
    
    static class RandomHandler
    {
       public static void CreateIntervals(List<ActionWithChance> list)
        {
            int currentBorderMin = 1;
            int currentBorderMax = 0;
            foreach (var actionWithChance in list)
            {
                actionWithChance.TempMin = currentBorderMin;
                actionWithChance.TempMax = currentBorderMax 
                                  + actionWithChance.Chance;
    
                currentBorderMax = actionWithChance.TempMax;
                currentBorderMin = currentBorderMax;
            }
        }
    
        public static void GetRandom(List<ActionWithChance> list)
        {
            Thread.Sleep(20);
            int allChance = list.Sum(i => i.Chance);
            Random rand = new Random();
            int nextValue = rand.Next(1, allChance + 1);
            ActionWithChance selectedAction = 
    list.FirstOrDefault(i => i.TempMin <= nextValue && i.TempMax >= nextValue);
    
            selectedAction.Chance = selectedAction.Chance > 5 
                ? selectedAction.Chance - 5 : 100;
    
            selectedAction.DoSomething();
        }
    }
    
    class ActionWithChance
    {
        public string Name { get; set; }
        public int Chance { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
    
        public void DoSomething()
        {
            Console.WriteLine(Name);
        }
    
    
        public ActionWithChance(string name, int chance)
        {
            Name = name;
            Chance = chance;
        }
    }
