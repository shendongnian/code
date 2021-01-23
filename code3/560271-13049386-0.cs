        protected override object SaveViewState()
        {
            object state = base.SaveViewState();
            // your custom save logic
        }
        protected override void LoadViewState(object savedState)
        {
            object state = // load your view state here
            base.LoadViewState(savedState);
        }
