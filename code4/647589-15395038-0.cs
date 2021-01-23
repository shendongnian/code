            List<Action> actions = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                Action anonymousFunction = () => Console.WriteLine(i);                
                actions.Add(anonymousFunction);
            }
            foreach (var action in actions)
            {
                action();//prints out the last value every time
            }
