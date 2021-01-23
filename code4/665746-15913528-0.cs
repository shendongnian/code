        interface IState
        {
             Task HandleAsync(Context context);
        }
        class Context
        {
            // ...
            public async Task RunAsync()
            {
                while (_state != null)
                {
                    await _state.HandleAsync(this);
                }
            }
        }
