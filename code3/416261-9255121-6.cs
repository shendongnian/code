    class Bus
    {
        Subject<Command> commands;
        Subject<Invocation> invocations;
        // TODO: Instantiate me
        List<Func<Command, bool>> handlerList; 
        public Bus()
        {
            this.commands = new Subject<Command>();
            this.invocations = new Subject<Invocation>();
            commands.SelectMany(x => {
                // This FirstOrDefault() is just good ol' LINQ
                var passedHandler = 
                    handlerList.FirstOrDefault(handler => handler(x) == true);
                return passedHandler != null ?
                    Observable.Return(new Invocation() { Command = x, Handled = true}) :
                    Observable.Throw<Invocation>(new Exception("Unhandled!"));
            }).Multicast(invocations).Connect();
        }
        /* ... snip ... */
    }
