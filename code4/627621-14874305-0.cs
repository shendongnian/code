    internal class Program
    {
        private static void Main(string[] args)
        {
            IColour[] items;
            items = new IColour[] { new SomeColour(), new SomeOtherColour() };
            Console.WriteLine(items.GetType().GetElementType().Name);  // Will always return IColour
            foreach (var item in items)
            {
                Console.WriteLine(item.GetType().Name); // Will return the name of type added with the IColour interface
            }
            Console.ReadLine();
        }
    }
    internal interface IColour
    { }
    internal class SomeColour : IColour
    { }
    internal class SomeOtherColour : IColour
    { }
