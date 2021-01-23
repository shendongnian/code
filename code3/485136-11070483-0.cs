    class ExpandingWindow
    {
         public virtual void Draw(D obj) { ... }
    }
    public class MainMenu : ExpandingWindow
    {
         public MainMenu(A a, B b)
         { 
             // assign MainMenu-specific parameters
         }
         // inherit Draw from the base class,
         // or override it if necessary
    }
  
    public class SideMenu : ExpandingWindow
    {
         public SideMenu(A a, B b, C c)
         { 
             // assign SideMenu-specific parameters
         }
         // inherit Draw from the base class,
         // or override it if necessary
         public override Draw(D d)
         {
             // some side-menu specific stuff
             d.DoStuff();
 
             // call the base method after that
             base.Draw(d);
         }
    }
