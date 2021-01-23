    public class Factory
    {
        public static Thing Create()
        {
            return new InternalThing();
        }
    }
    public abstract class Thing {}
    internal class InternalThing : Thing
    {
        public int Value {get; set;}
    }
------------
    > csc /t:library bar.cs
