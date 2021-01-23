    Action<IEnumerable<int>> dump = null;
    dump = items =>
                {
                    if(!items.Any())
                    {
                        return;
                    }
                    var head = String.Join("", items.Take(4));
                    Console.Out.WriteLine(head);
                    var tail = items.Skip(4);
                    dump(tail);
                };
    
    dump(guesses);
