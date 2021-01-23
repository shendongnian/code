    public void SetContentObject(Type contentType)
        {
            Type input;
            Dispatcher.BeginInvoke(new Action(delegate
            {
                   object obj = Activator.CreateInstance(input);
                   this.Content = obj;               
          
            }), new object[]
            {
                contentType
            });
        }
