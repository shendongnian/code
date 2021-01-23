    Action<object> action = (o) => Console.WriteLine(o.ToString());
    
    public void processAction(Action<object> actionToRun, object i) {
        action(i);
    }
