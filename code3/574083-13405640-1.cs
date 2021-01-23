    public class FakeStuff
    {
         public static IEnumerable<Pony> JustSomeGenericPonies(int numberOfPonies)
         {
            // return just some basic list
             return new List<Pony>{new Pony{Colour = "Brown", Awesomeness = AwesomenessLevel.Max}};
             // or could equally just go bananas in here and do stuff like...
             var lOfP = new List<Pony>();
             for(int i = 0; i < numberOfPonies; i++)
             {
                 var p = new Pony();
                 if(i % 2 == 0) 
                 {
                     p.Colour = "Gray";
                 }
                 else
                 {
                     p.Colour = "Orange"; 
                 }
                 lOfP.Add(p);
             }
             return lOfP;
         }
    }
