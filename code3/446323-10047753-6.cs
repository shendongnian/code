    public class Ninja
    {
      public string Name { get; set; }
      public int Level { get; set; }
      public int Shurikens { get; set; }
      public Skill Skill { get; set; }
    }
    
    public enum Skill
    {
      None = 1,
      HideInShadows
    }
