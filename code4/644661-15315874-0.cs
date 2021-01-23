    public class Foo {
      private string _bar;
      public string Bar 
      {
        get { return String.IsNullOrEmpty(_bar) ? _bar = "default value" : _bar; }
        set { _bar = value; }
      } 
    }
