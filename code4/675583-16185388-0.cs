    public void SetContentObject(Type contentType)
        {
            this.Dispatcher.BeginInvoke(delegate() //Error here <-
            {
                object obj = Activator.CreateInstance(contentType);
                this.Content = obj;//this.Content declared as object
            }, new object[]
            {
                contentType
            });
        }
