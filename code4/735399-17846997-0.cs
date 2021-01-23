    public interface IPositioned
    {
      float X { get; }
      float Y { get; }
    }
    public class Me: IPositioned { /* ... */ }
    public class Enemy: IPositioned { /* ... */ }
    /* ... */
    public void CollisionCheck(IPositioned me, IPositioned other)
    {
       if (me.x < enemy.x)
       {
          Console.Write("foo");
       }
    }
