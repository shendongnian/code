    MyControl.Click += async (sender, args) => {
        // await...
    }
    
    MyControl.Click += (sender, args) => {
        // synchronous code
        return Task.CompletedTask;
    }
