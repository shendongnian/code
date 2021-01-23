    class TheObject
    {
        public event EventHandler<GameStateEvents> StateChanged;
        // If your object changes state, this function should be called. It informs all observers by invoking the StateChanged delegate.
        protected virtual void OnStateChanged(GameStateEvents e)
        {
            if (StateChanged != null) 
                StateChanged(this, e);
        }
    }
    class TheObserver
    {
         public TheObserver(TheObject o)
         {
             o.StateChanged += Object_StateChanged;
         }
         // This function is called by the object when the object changes state.
         private void Object_StateChanged(object sender, GameStateEvents e)
         {
         }
    }
