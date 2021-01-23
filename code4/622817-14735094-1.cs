    //done by both subscriber and publisher
    Mediator.Instance.Register(this);
    //Subscriber
    [MediatorMessageSinkAttribute("DoBackgroundCheck")]
    void OnBackgroundCheck(string someValue) { ... }
    //publisher might typically do this
    mediator.NotifyColleagues("DoBackgroundCheck", "Nice message");
