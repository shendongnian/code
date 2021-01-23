    //what you have
    public void RunThatAction(Action TheAction)
    {
      TheAction()
    }
    //how you call it
    Action doManyThings = () =>
    {
      DoThatThing();
      DoThatOtherThing();
    }
    RunThatAction(doManyThings);
