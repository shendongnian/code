    <span class='keyword'>using</span> System;
    <span class='keyword'>namespace</span> Foo.Bar
    {
      public class Baz
      {
        public static void Main()
        {
          String[] a = new[]{"foo","bar","baz"};
          <span class='keyword'>foreach</span> (var b in a) Console.WriteLine(b);
        }
      }
    }
