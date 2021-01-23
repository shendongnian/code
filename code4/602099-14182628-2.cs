    class Unit
    {
       private static Texture2D s_unitTexture = content.Load<Texture2D>("worker");
       protected virtual Texture2D BaseTexture
       {
          get { return s_unitTexture; }
       }
       public Texture2D Texture { get; set; }
    
       public Unit()
       {
           this.Texture = BaseTexture;
       }
       ...
    }
    
    class Soldier : Unit
    {
       private static Texture2D s_soldierTexture = content.Load<Texture2D>("soldier");
       protected override Texture2D BaseTexture
       {
          get { return s_soldierTexture; }
       }
    
       ...
    }
