    class Program : Base
    {
      protected void Foo(object bar, object baz)
      {
      }
      protected new void Foo(object bar, DayOfWeek baz)
      {
        base.Foo(bar, baz);
      }
      void Bar(DayOfWeek day)
      {
        base.Foo(new { day }, day);
      }
    }
