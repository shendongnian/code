    public ImageWidgetViewModel(IImageWidget widget, IAnotherDependency d) { }
    
    public TextWidgetViewModel(ITextWidget widget) { }
    
    public ContainerViewModel(object data, IFactory<IWidget, IWidgetViewModel> factory)
    {
    	IList<IWidgetViewModel> children = new List<IWidgetViewModel>();
    	foreach (IWidget w in data.Widgets)
    		children.Add(factory.Create(w));
    }
    
