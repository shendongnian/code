		public void Consume(ImageFound message)
		{
			var model = _container.Resolve<ChoiceViewModel>();
			model.ForImage(message);
			this.BeginInvoke(() => _windows.ShowWindow(model));
		}
