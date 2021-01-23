    interface IPartGenerator
    {
       void GeneratePart();
    }
    
    class SmallPartGenerator : IPartGenerator
    {
       void GeneratePart();
    }
    
    class OtherSmallPartGenerator : IPartGenerator
    {
       void GeneratePart();
    }
    
    class TinyPartGenerator : IPartGenerator
    {
       void GeneratePart();
    }
    
    class FooGenerator:IFooGenerator 
    {
       private IPartGenerator[] partGenerators = new IPartGenerator[] 
                            {
                               new SmallPartGenerator(), 
                               new OtherSmallPartGenerator(), 
                               new TinyPartGenerator ()
                            }
    
       public void Generate()
       {
            foreach (var partGenerator in partGenerators)
            {
                  partGenerator.GeneratePart();
            }
       }
    }
