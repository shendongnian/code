    private readonly ConcurrentDictionary<string,IView> _openedViews = 
              new ConcurrentDictionary<string,IView>();
    
    public MainView() 
    {
        Messenger.Default.Register<ViewChangeMessage>(this, "adminView", m =>
        {
             var key = m.ViewName;
             content.Content = _openedViews.GetOrAdd(key, GetView(key));
             //...
        });
        //...
    
        
