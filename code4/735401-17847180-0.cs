    public class Transform
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
    
    public interface IHasTransform
    {
        Transform SomeTransform { get; set; }
    }
    
    public class You : IHasTransform
    {
        public Transform SomeTransform { get; set; }
    }
    public class Me : IHasTransform
    {
        public Transform SomeTransform { get; set; }
    
        public void CollisionCheck<T>(T other) where T : IHasTransform
        {
            if (this.SomeTransform.X < other.SomeTransform.X)
                Console.WriteLine("foo");
        }
    }
