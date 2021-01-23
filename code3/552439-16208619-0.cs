    class Program
    {
        static void Main(string[] args)
        {
            List<Array> _list = new List<Array>();
            _list.Add(new int[2] { 100, 200 });
            _list.Add(new string[2] { "John", "Ankush" });
            foreach (Array _array in _list)
            {
                if (_array.GetType() == typeof(Int32[]))
                {
                    foreach (int i in _array)
                        Console.WriteLine(i);
                }
                else if (_array.GetType() == typeof(string[]))
                {
                    foreach (string s in _array)
                        Console.WriteLine(s);
                }
            }
            Console.ReadKey();
        }
    }
