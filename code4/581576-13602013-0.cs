    public class Animal
    {
        public List<Mammal> GetMammalList(Mammal mammal)
        {
            List<Mammal> list = new List<Mammal>();
            if (mammal.GetType() == typeof(Horse))
                for (int x = 0; x < 10; x++)
                    list.Add(new Horse());
            else if (mammal.GetType() == typeof(Cow))
                for (int x = 0; x < 10; x++)
                    list.Add(new Cow());
            else
                throw new ArgumentOutOfRangeException();
    
            return list;
        }
    }
    
    public class Mammal : Animal { }
    
    public class Horse : Mammal { }
    
    public class Cow : Mammal { }
