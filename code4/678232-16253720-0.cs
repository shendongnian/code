    public class OtherClass
    {
          ContentManager content;
          public OtherClass(IServiceProvider serviceProvider)
          {
              content = new ContentManager(serviceProvider, "Content");
          }
          public void LoadStuff()
          {
               content.Load<Texture2D>("x");
          }
    }
    
    public class Game1
    { 
         public void DoStuff()
         {
             OtherClass other = new OtherClass(Services);
             other.LoadStuff();
         }
    }
