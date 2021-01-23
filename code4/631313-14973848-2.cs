    public abstract class Control
    {
    }
    public class TextBox : Control, ITextControl
    {
      public virtual string Text { get; set; }
    }
    public class ConcreteControlMap<T> : SubclassMap<T> where T : Control
    {
      public ConcreteControlMap()
      {
        if(typeof(ITextControl).IsAssignableFrom(typeof(T)))
        {
          Map(c => ((ITextControl)c).Text);
        }
      }
    }
