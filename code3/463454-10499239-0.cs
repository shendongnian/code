    var items = input.Split('\n');
    Func<string, string> f = s =>
        {
            var strings = s.Split(new[] {':'}, 2);
            var key = strings[0];
            var value = strings[1];
            switch (key.ToLower())
            {
                case "start":
                    return s;
                case "value":
                    return String.Format("{0}: {1}", key, Int32.Parse(value) + 1);
                case "end": 
                    return String.Format("{0}: {1:h:mm}", key,
                                        DateTime.Parse(value) +
                                        TimeSpan.FromMinutes(30));
                default:
                    return "";
            }
        };
    var resultItems = items.Select(f);
    
    Console.Out.WriteLine("result = {0}",
                            String.Join(Environment.NewLine, resultItems));
