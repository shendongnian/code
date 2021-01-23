      public class Box
      {
           private Box() {}
           private Box(Color color) { Color = color; }
           public static Box Make(Color color) { return new Box(color); }
           public static Box RedBox { get { return new Box(Color.Red); } }
           public static Box GreenBox { get { return new Box(Color.Green); } }
           public static Box BlueBox { get { return new Box(Color.Blue); } }
           //   ... etc.
       }
