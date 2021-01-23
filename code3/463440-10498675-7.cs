    public void Consume(ImageFound message)
    {
    	var model = _container.Resolve<ChoiceViewModel>();
    	model.ForImage(message);
    	UIDispatcher.BeginInvoke(new Action(() => _windows.ShowWindow(model)));
    }
