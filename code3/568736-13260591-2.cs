        var myAction = new Action(() =>
             {
                  // Some Complex Logic
                  DoSomething(15, "Something");
                  // More Complex Logic, etc
             });
        InvokeLater(myAction);
        public void InvokeLater(Action action)
        {
              action();
        }
    All of the data is captured in a closure of your method, and thus is saved. So if you can manage to pass along an `Action` to your event with the `e.Argument` property, all you would need to do would be to call `(e.Argument as Action)()`. 
