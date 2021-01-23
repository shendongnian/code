    private static void DoAction(params Expression<Action<Group>>[] actions)
    {
        foreach (var exp in actions)
        {
            var method = exp.Body as MethodCallExpression;
            if(method != null)
                Console.WriteLine(method.Method.Name);
            // similar method for properties
            var member = exp.Body as MemberExpression;
            if (member != null)
                Console.WriteLine(member.Member);
            // execute the Action
            Action<Group> act = exp.Compile();
            Group g = new Group();  // create a Group to act on
            act(g);  // perform the action
        }
    }
