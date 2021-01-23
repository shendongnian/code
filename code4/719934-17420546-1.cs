    static class Program {
        static Random Clone(this Random source)
        {
            var clone = new Random();
            var type = typeof(Random);
            var field = type.GetField("inext",
                BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(clone, field.GetValue(source));
            field = type.GetField("inextp",
                BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(clone, field.GetValue(source));
            field = type.GetField("SeedArray",
                BindingFlags.Instance | BindingFlags.NonPublic);
            int[] arr = (int[])field.GetValue(source);
            field.SetValue(clone, arr.Clone());
            return clone;
        }
        static void Main()
        {
            Random rand = new Random();
            var clone = rand.Clone();
            Console.WriteLine("My predictions:");
            Console.WriteLine(clone.Next());
            Console.WriteLine(clone.Next());
            Console.WriteLine(clone.Next());
            Console.WriteLine("Actual:");
            Console.WriteLine(rand.Next());
            Console.WriteLine(rand.Next());
            Console.WriteLine(rand.Next());
        }
    }
