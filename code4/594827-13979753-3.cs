    Action<object> anAction = o => { Console.WriteLine(o); };
    Func<object, int> aFunc = o =>
        {
            var s = (o ?? "").ToString();
            Console.WriteLine(s);
            return s.Length;
        };
