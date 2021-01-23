    class Utils
    {
        static void dump<T>(IEnumerable<T> list, string glue="\n")
        {
            Console.WriteLine(string.Join(glue, list.Select(x => x.ToString())));
        }
    }
