    public void MyCallingMethod()
    {
        myMethodAsync().ContinueWith(
            result =>
            {
                // do stuff with the result
            });
    }
