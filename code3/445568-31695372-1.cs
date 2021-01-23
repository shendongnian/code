    ISourceBlock`<T`> mySource = ...;
    while (await mySource.ReceiveAsync())
    {   // a object of type T is available at the source
        T objectToProcess = await mySource.ReceiveAsync();
        // keep in mind that someone else might have fetched your object
        // so only process it if you've got it.
        if (objectToProcess != null)
        {
            await ProcessAsync(objectToProcess);
            // if your processing produces output send the output to your target:
            var myOutput = await ProduceOutput(objectToprocess);
            await myTarget.SendAsync(myOutput);
        }
    }
    // if here, no input expected anymore, notify my consumers:
    myTarget.Complete();
