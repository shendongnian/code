    class Program
    {
        static void Main(string[] args)
        {
            var subs = new Substitutes {{'a', 'b'}, {'c', 'd'}};
            Console.WriteLine(subs['a']); //Prints b
            Console.WriteLine(subs['b']); //Prints a
        }
        class Substitutes : Dictionary<char, char>
        {
             public new void Add(char item, char substitute)
             {
                 base.Add(item, substitute);
                 base.Add(substitute, item);
             }
        }
    }
