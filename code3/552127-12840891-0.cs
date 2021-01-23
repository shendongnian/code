    public interface IWidgetBase
    {
      bool SomeBool { get; }
      void DoWidgetyStuff();
    }
    public static class IWidgetBaseExtensions
    {
      public static void WidgetStuff(this IWidgetBase base)
      {
        if (base.SomeBool) 
          base.DoWidgetyStuff();
      }
    }
    public class ScrollerBase : Control, IWidgetBase
    {
      public bool SomeBool { get; protected set; }
      public void DoWidgetyStuff() {
        // Do stuff
      }
    }
        
    // Main code:
    IWidgetBase myScroller = new ScrollerBase();
    myScroller.WidgetStuff();
   
