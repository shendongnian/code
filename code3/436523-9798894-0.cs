    public void ClosedEventHandlerIsNotCalledAfterBeingRemoved()
    {
        MyClass Target = new MyClass();
        EventHandler Target_Closed = new EventHandler((sender, e) => { Assert.Fail("Closed EventHandler was raised after being removed."); });
        Target.Closed += Target_Closed;
        Target.Closed -= Target_Closed;
        Target.Close();
    }
