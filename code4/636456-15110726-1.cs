     bool eventFired = false;
    
     var tellDontAsk = new SimpleTellDontAsk();
     tellDontAsk.RaiseEvent += (o, e) =>
                {
                    if (e.IsDo)
                        eventFired = true;
                };
     tellDontAsk.doSomething("test message");
     Assert.IsTrue(eventFired);
