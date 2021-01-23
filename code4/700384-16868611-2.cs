    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "A", "B", "C" };
            List<Action> actions = new List<Action>();
            string name = names[0];
            Action test = () => Console.WriteLine(name);
            for (int i = 0; i < names.Count; i++)
			{
                actions.Add(test);
			}
            name = names[1];
            foreach (var action in actions)
            {
                action.Invoke(); // Prints "B" every time because name = names[1]
            }
            Console.ReadLine();
        }
    }
