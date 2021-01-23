    public interface IThing
    {
        string Name { get; }
    }
    public class Thing : IThing
    {
        public string Name { get; set; }
    }
    public abstract class ThingConsumer<T> where T : IThing
    {
        public string Name { get; set; }
    }
    public class MyThingConsumer : ThingConsumer<Thing>
    {
    }
    public static class ThingConsumerFactory<T> where T : IThing
    {
        public static ThingConsumer<T> GetThingConsumer()
        {
            if (typeof(T) == typeof(Thing))
            {
                return new MyThingConsumer() as ThingConsumer<T>;
            }
            else
            {
                return null;
            }
        }
    }
    ...
    var thing = ThingConsumerFactory<Thing>.GetThingConsumer();
    Console.WriteLine(thing);
