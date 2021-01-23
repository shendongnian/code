            List<Action> actions = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                int copyOfOriginalValue = i;
                Action anonymousFunction = () => Console.WriteLine(copyOfOriginalValue);                
                actions.Add(anonymousFunction);
            }
            foreach (var action in actions)
            {
                action();//prints out unique values
            }
