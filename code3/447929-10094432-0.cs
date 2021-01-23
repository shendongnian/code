    class Caller {
        public void Call() {
            new Callee().DoSomething(this.Callback); // Pass in a delegate of this instance
        }
    
        public void Callback() {
            Console.WriteLine("Callback called!");
        }
    }
    
    class Callee {
        public void DoSomething(Action callback) {
            // Do stuff
            callback(); // Call the callback
        }
    }
    ...
    new Caller().Call(); // Callback called!
