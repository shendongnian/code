        // you could place the priorities in a service to reuse it
        var priorities = new HashSet<NodeMoving>();
        priorities.Add(new RightExists());
        priorities.Add(new PushedLeft());
        var currentPosition = new MyClass { X = 1, Y = 2 };
        foreach (var priority in priorities)
        {
            if (priority.IsValid(currentPosition))
            {
                priority.Move();
                break;
            }
        }
        // output is: RightExists
        // now changing the priority order
        foreach (var priority in priorities.Reverse())
        {
            if (priority.IsValid(currentPosition))
            {
                priority.Move();
                break;
            }
        }
        // output is: PushedLeft
