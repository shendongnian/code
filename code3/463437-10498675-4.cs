    public void Consume(ImageFound message)
    {
    	var model = _container.Resolve<ChoiceViewModel>();
    	model.ForImage(message);
    	_uiDispatch.BeginInvoke(new Action(() => _windows.ShowWindow(model)));
    }
