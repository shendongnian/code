    void Main()
    {
        var lions = new Dictionary<string, Lion>();
        lions.Add("one", new Lion{Name="Ben"});
        AnimalManipulator.DoStuffWithAnimals(lions);
    }
    public class AnimalManipulator
    {
        public static void DoStuffWithAnimals<T>(IDictionary<string, T> animals)
        where T : Animal
        {
            foreach (var kvp in animals)
            {
                kvp.Value.MakeNoise();
            }
        }
    }
    public class Animal
    {
        public string Name {get;set;}
        public virtual string MakeNoise()
        {
            return "?";
        }
    }
    public class Lion : Animal
    {
        public override string MakeNoise()
        {
            return "Roar";
        }
    }
