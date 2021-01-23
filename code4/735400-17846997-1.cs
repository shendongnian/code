    public interface IPositioned
    {
      float X { get; }
      float Y { get; }
    }
    public class Me: IPositioned { /* ... */ }
    public class Enemy: IPositioned { /* ... */ }
    /* ... */
    public void CollisionCheck(IPositioned me, IPositioned enemy)
    {
       if (me.X < enemy.X)
       {
          Console.Write("foo");
       }
    }
