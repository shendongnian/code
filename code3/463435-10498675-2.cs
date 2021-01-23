    public void Consume(ImageFound message)
    {
    	var model = _container.Resolve<ChoiceViewModel>();
    	model.ForImage(message);
    	this.Invoke( () => _windows.ShowWindow(model) );
    }
