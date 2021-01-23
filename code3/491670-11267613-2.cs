    public interface IScopable { 
      void EndScope();
    }
    public class Tag : IScopable {
      private string name;
      public Tag(string name) {
        this.name = name;
        Trace.WriteLine("<" + this.name + ">");
        Trace.Indent();
      }
      public void EndScope() {
        Trace.Unindent();
        Trace.WriteLine("</" + this.name + ">");
      }
    }
    public static class Scoping {
      public static void Scope<T>(this T scopable, Action<T> action) 
        where T : IScopable {
        action(scopable);
        scopable.EndScope();
      }
    }
