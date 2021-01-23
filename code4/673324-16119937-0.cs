    //Registering in form
    var container = TinyIoCContainer.Current;
    container.Register<IMessageDeliverer>(this);
    
    //Resolving in Module Constructor
    var container = TinyIoCContainer.Current;
    IMessageDeliverer mdl = container.Resolve<IMessageDeliverer>();
    setDeliverer(mdl);
