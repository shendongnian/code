    public class Foo
    {
      private string m_value;
      public string Value { get { return m_value; } set { m_value = value; } }
      public Foo()
      {
        m_value = "";
      }
      public override bool Equals(object obj)
      {
        return this.Value == obj.ToString();
      }
      public override int GetHashCode()
      {
        return Value.GetHashCode();
      }
      public static bool operator ==(Foo a, string b)
      {
        return a.Value == b;
      }
      public static bool operator !=(Foo a, string b)
      {
        return a.Value != b;
      }
    }
