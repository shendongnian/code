    var ctx = new StreamingContext(StreamingContextStates.File,
        new MyStreamingContext { File = "SomeFile" });
    ...
    class MyStreamingContext {
        public string File {get;set;}
    }
    ...
    var context = c == null ? null : c.Context as MyStreamingContext;
    if(context != null) {
        string file = context.File;
        // ...
    }
