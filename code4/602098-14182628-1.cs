    class Unit
    {
       private static Texture2D s_unitTexture = content.Load<Texture2D>("worker");
       public virtual Texture2D Texture
       {
          get { return s_unitTexture; }
       }
    
       pubic void Draw(SpriteBatch sb)
       {
           Texture.DoSomething();
           ...
       }
       ...
    }
    
    class Soldier : Unit
    {
       private static Texture2D s_soldierTexture = content.Load<Texture2D>("soldier");
       public override Texture2D Texture
       {
          get { return s_soldierTexture; }
       }
    
       ...
    }
