    public interface IClown
    {
      string FunnyThingIHave { get; }
      void Honk();
    }
    public class TallGuy : IClown
    {
      public string FunnyThingIHave {
      get { return "big shoes"; }
    }
      public void Honk() {
        MessageBox.Show("Honk honk!");
      }
    }
    public class Joker:IClown
    {
      public string FunnyThingIHave
      {
        get {return "I have a clown car"}
      }
      public void Honk()
      {
        MessageBox.Show("Honk Bonk");
      }
    }
    
    public class FunnyClowns 
    {
      Joker joker = new Joker();
      TallGuy tguy = new TallGuy();
    
      string WhichFunnyThingIWant(IClown clownType)
      {
         clownType.Honk();
      }
    }
