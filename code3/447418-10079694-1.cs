    MethodInfo methodInfo = MyLogging.GetMyMethodInfo();
    ParameterBlob[] blobs = new ParameterBlobs[MyLogging.GetMyParameterCount(methodInfo);
    ParameterBlob blob = new ParameterBlob();
    blob.Info = MyLogging.GetParameterInfo(methodInfo, 0);
    blob.Value = param0; // More on this
    blobs[0] = blob;
    blob = new ParameterBlob();
    blob.Info = MyLogging.GetParameterInfo(methodInfo, 1);
    blob.Value = param1; // More on this
    blobs[1] = blob;
    // ...
    blob = new ParameterBlob();
    blob.Info = MyLogging.GetParameterInfo(methodInfo, n);
    blob.Value = paramn; // more on this
    blobs[n] = blob;
    MyLogging.LogMethodCall(methodInfo, blobs);
