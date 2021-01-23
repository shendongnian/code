    var wc = new WebClient();
    using(var sourceStream = wc.OpenRead(Blob.Uri.AbsoluteUri)){
        using(var reader = new StreamReader(sourceStream)){
             // Process
        }
    }
