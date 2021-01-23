        public void MyAction()
    {
        // property bound to the adorner VisibiltyProperty
        // I like the happen a refresh now
        // (code is wired correct, if I finish method here, the adorner is drawn)
        this.IsAdornerEnabled = true;
        try
        {
			this.Dispatcher.Invoke( (Action)(() => 
			{ 
				// Do your work here,
				
				
				
				
				
				this.IsAdornerEnabled = false;
			})); 
        }catch {
		}
    }
