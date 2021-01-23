    public void SetContentObject(Type contentType)
        {
            Type input;
            this.Dispatcher.BeginInvoke(delegate() 
            {
                object obj = Activator.CreateInstance(input);
                this.Content = obj;
            }, new object[]
            {
                contentType
            });
        }
