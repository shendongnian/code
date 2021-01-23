    public void SomeAsycMethod ( Action<object> onCompleteCallBack )
    {
        // get the current context
        var context = SynchronizationContext.Current;
        Task.Factory.StartNew( () =>
        {
            Thread.Sleep( 1000 );// do some work;
            // lastly call the onCompleteCallBack on 'ThisThread'
            onCompleteCallBack( "some result" );
            // I am looking for something like:
            context.Post(s => onCompleteCallBack ("some result"), null); 
        });
    }
